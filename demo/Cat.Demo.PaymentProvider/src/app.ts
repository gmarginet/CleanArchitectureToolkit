import { STATUS_CODES } from "node:http";
import Fastify, { type FastifyInstance, type FastifyReply } from "fastify";
import type { ChargeRequest, RefundRequest } from "./models.ts";
import { loadApiDocument } from "./openapi.ts";
import { PaymentProcessor } from "./paymentProcessor.ts";
import type { Settings } from "./settings.ts";

// A stand-in for an outside payment provider. It is a plain REST API and it shares nothing with the shop
// but the OpenAPI contract in openapi.json and an API key. A caller sends the API key as a bearer token
// and an Idempotency-Key header.

type Options = {
  // Writes one JSON line per request to stdout. The dashboard shows it as the console log.
  logger?: boolean;
  // Gives a number from 0 to 99, for a test that needs a fixed outcome of the error percentage.
  nextPercentage?: () => number;
};

export async function buildApp(settings: Settings, options: Options = {}): Promise<FastifyInstance> {
  const app = Fastify({
    logger: options.logger ?? false,
    ajv: {
      customOptions: {
        // Numbers are numbers only, so a string in the amount is a bad request and not a number.
        coerceTypes: false,
        strict: false,
        // The contract says format decimal for the amount, so money stays a decimal in the client of the shop.
        formats: { decimal: () => true },
      },
    },
  });

  const processor = new PaymentProcessor(settings.failures, options.nextPercentage);
  const api = loadApiDocument(new URL("../openapi.json", import.meta.url));

  // Every error is a problem document with the ProblemDetails shape of the contract.
  app.setErrorHandler((error: { statusCode?: number; message: string }, request, reply) => {
    const status = error.statusCode !== undefined && error.statusCode >= 400 ? error.statusCode : 500;
    if (status >= 500) {
      request.log.error({ err: error }, "The request failed.");
    }

    return problem(reply, status, status >= 500 ? "An error occurred." : error.message);
  });
  app.setNotFoundHandler((_request, reply) => problem(reply, 404, "There is nothing at this address."));

  app.get("/health", () => ({ status: "Healthy" }));

  if (process.env.NODE_ENV !== "production") {
    app.get("/openapi/v1.json", (_request, reply) => reply.type("application/json").send(api.raw));
  }

  // The handlers are looked up by operation id, the same name that the generated client of the shop uses.
  const handlers: Record<string, (request: { body: unknown; headers: Record<string, unknown> }, reply: FastifyReply) => Promise<unknown>> = {
    CreateCharge: async (request, reply) => {
      const key = idempotencyKey(request.headers);
      const body = request.body as ChargeRequest;
      if (key === undefined || body.orderNumber.trim() === "" || body.amount <= 0) {
        return problem(reply, 400, "An Idempotency-Key header, an order number and an amount above zero are required.");
      }

      const outcome = await processor.charge(key, body);
      return outcome.failed ? failing(reply) : outcome.response;
    },
    CreateRefund: async (request, reply) => {
      const key = idempotencyKey(request.headers);
      const body = request.body as RefundRequest;
      if (key === undefined || body.orderNumber.trim() === "") {
        return problem(reply, 400, "An Idempotency-Key header and an order number are required.");
      }

      const outcome = await processor.refund(key, body);
      return outcome.failed ? failing(reply) : outcome.response;
    },
  };

  // The provider knows its caller by the API key. A call without the right key gets 401, before anything else is checked.
  await app.register(async (provider) => {
    provider.addHook("onRequest", async (request, reply) => {
      if (settings.apiKey === "" || request.headers.authorization !== `Bearer ${settings.apiKey}`) {
        return problem(reply, 401, "The API key is missing or wrong.");
      }
    });

    for (const operation of api.operations) {
      const handler = handlers[operation.operationId];
      if (handler === undefined) {
        throw new Error(`The document has the operation '${operation.operationId}', and the provider has no handler for it.`);
      }

      provider.route({
        method: operation.method as "POST",
        url: operation.path,
        schema: { headers: operation.headersSchema, body: operation.bodySchema },
        handler: (request, reply) => handler(request as never, reply),
      });
    }
  });

  return app;
}

function idempotencyKey(headers: Record<string, unknown>): string | undefined {
  const key = headers["idempotency-key"];
  return typeof key === "string" && key.trim() !== "" ? key : undefined;
}

function failing(reply: FastifyReply): FastifyReply {
  return problem(reply, 503, "The payment provider is failing on purpose.");
}

function problem(reply: FastifyReply, status: number, detail: string): FastifyReply {
  return reply.code(status).type("application/problem+json").send({
    type: `https://httpstatuses.io/${status}`,
    title: STATUS_CODES[status] ?? "Error",
    status,
    detail,
  });
}
