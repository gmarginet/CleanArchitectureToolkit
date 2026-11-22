import { readFileSync } from "node:fs";

// The contract is a static file, openapi.json. It is the document that the shop keeps a copy of and generates its client from.
// This loader reads the request schemas from it, so Fastify checks every request against the same document that it serves.

export type JsonSchema = Record<string, unknown>;

export type Operation = {
  operationId: string;
  method: string;
  path: string;
  headersSchema: JsonSchema | undefined;
  bodySchema: JsonSchema | undefined;
};

export type ApiDocument = {
  raw: unknown;
  operations: Operation[];
};

type RawDocument = {
  paths: Record<string, Record<string, RawOperation>>;
  components?: { schemas?: Record<string, JsonSchema> };
};

type RawOperation = {
  operationId: string;
  parameters?: { name: string; in: string; required?: boolean; schema: JsonSchema }[];
  requestBody?: { content?: Record<string, { schema?: JsonSchema }> };
};

export function loadApiDocument(file: URL): ApiDocument {
  const raw = JSON.parse(readFileSync(file, "utf8")) as RawDocument;
  const schemas = raw.components?.schemas ?? {};
  const operations: Operation[] = [];

  for (const [path, methods] of Object.entries(raw.paths)) {
    for (const [method, operation] of Object.entries(methods)) {
      const headers = (operation.parameters ?? []).filter((parameter) => parameter.in === "header");
      const body = operation.requestBody?.content?.["application/json"]?.schema;

      operations.push({
        operationId: operation.operationId,
        method: method.toUpperCase(),
        path,
        // Node.js gives header names in lower case, so the schema uses lower case too.
        headersSchema:
          headers.length === 0
            ? undefined
            : {
                type: "object",
                properties: Object.fromEntries(
                  headers.map((header) => [header.name.toLowerCase(), inline(header.schema, schemas)]),
                ),
                required: headers.filter((header) => header.required).map((header) => header.name.toLowerCase()),
              },
        bodySchema: body === undefined ? undefined : (inline(body, schemas) as JsonSchema),
      });
    }
  }

  return { raw, operations };
}

// Replaces every $ref to a component with the schema itself, so a route schema stands on its own.
function inline(node: unknown, schemas: Record<string, JsonSchema>): unknown {
  if (Array.isArray(node)) {
    return node.map((item) => inline(item, schemas));
  }

  if (node !== null && typeof node === "object") {
    const object = node as Record<string, unknown>;
    const reference = object["$ref"];
    if (typeof reference === "string") {
      const name = reference.replace("#/components/schemas/", "");
      const target = schemas[name];
      if (target === undefined) {
        throw new Error(`The document refers to the schema '${name}', which it does not have.`);
      }

      return inline(target, schemas);
    }

    return Object.fromEntries(Object.entries(object).map(([key, value]) => [key, inline(value, schemas)]));
  }

  return node;
}
