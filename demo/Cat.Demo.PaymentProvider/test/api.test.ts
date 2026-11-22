import assert from "node:assert/strict";
import { test } from "node:test";
import { buildApp } from "../src/app.ts";
import { readSettings } from "../src/settings.ts";

// These tests drive the requests through Fastify with inject, so no port is opened.

const apiKey = "test-key";

async function app(env: Record<string, string> = {}) {
  return buildApp(readSettings({ PROVIDER_API_KEY: apiKey, ...env }));
}

function post(url: string, body: unknown, headers: Record<string, string> = {}) {
  return {
    method: "POST" as const,
    url,
    headers: { authorization: `Bearer ${apiKey}`, "idempotency-key": "key-1", ...headers },
    payload: body as object,
  };
}

test("a charge is approved and a repeated key gets the same answer", async () => {
  const provider = await app();

  const first = await provider.inject(post("/charges", { orderNumber: "20261106-9001", amount: 42.5 }));
  const second = await provider.inject(post("/charges", { orderNumber: "20261106-9001", amount: 42.5 }));

  assert.equal(first.statusCode, 200);
  assert.equal(first.json().status, "approved");
  assert.deepEqual(second.json(), first.json());
});

test("a charge above 500 euro is declined with status 200", async () => {
  const response = await (await app()).inject(post("/charges", { orderNumber: "20261106-9002", amount: 500.01 }));

  assert.equal(response.statusCode, 200);
  assert.deepEqual(response.json(), { status: "declined", reference: null });
});

test("a call with a wrong API key gets 401 as a problem document", async () => {
  const response = await (await app()).inject(
    post("/charges", { orderNumber: "x", amount: 10 }, { authorization: "Bearer not-the-key" }),
  );

  assert.equal(response.statusCode, 401);
  assert.match(response.headers["content-type"] as string, /application\/problem\+json/);
  assert.equal(response.json().status, 401);
});

test("a call without an idempotency key gets 400", async () => {
  const response = await (await app()).inject(
    post("/charges", { orderNumber: "x", amount: 10 }, { "idempotency-key": "" }),
  );

  assert.equal(response.statusCode, 400);
  assert.match(response.headers["content-type"] as string, /application\/problem\+json/);
});

test("a charge with no order number or an amount of zero gets 400", async () => {
  const provider = await app();

  const noOrder = await provider.inject(post("/charges", { orderNumber: "", amount: 10 }));
  const noAmount = await provider.inject(post("/charges", { orderNumber: "x", amount: 0 }));
  const missing = await provider.inject(post("/charges", {}));

  assert.equal(noOrder.statusCode, 400);
  assert.equal(noAmount.statusCode, 400);
  assert.equal(missing.statusCode, 400);
});

test("an amount that is a string gets 400, because numbers are numbers only", async () => {
  const response = await (await app()).inject(post("/charges", { orderNumber: "x", amount: "10" }));

  assert.equal(response.statusCode, 400);
});

test("a refund of an approved charge is refunded, and of a declined one it is nothing_to_refund", async () => {
  const provider = await app();
  await provider.inject(post("/charges", { orderNumber: "20261106-9001", amount: 42.5 }));
  await provider.inject(post("/charges", { orderNumber: "20261106-9002", amount: 500.01 }, { "idempotency-key": "key-2" }));

  const refunded = await provider.inject(post("/refunds", { orderNumber: "20261106-9001" }, { "idempotency-key": "refund-1" }));
  const nothing = await provider.inject(post("/refunds", { orderNumber: "20261106-9002" }, { "idempotency-key": "refund-2" }));

  assert.deepEqual(refunded.json(), { status: "refunded" });
  assert.deepEqual(nothing.json(), { status: "nothing_to_refund" });
});

test("an outage answers 503", async () => {
  const provider = await app({ FAILURE_OUTAGE: "true" });

  const response = await provider.inject(post("/charges", { orderNumber: "x", amount: 10 }));

  assert.equal(response.statusCode, 503);
  assert.equal(response.json().status, 503);
});

test("the health check and the OpenAPI document need no key", async () => {
  const provider = await app();

  const health = await provider.inject({ method: "GET", url: "/health" });
  const document = await provider.inject({ method: "GET", url: "/openapi/v1.json" });

  assert.equal(health.statusCode, 200);
  assert.equal(document.statusCode, 200);
  assert.equal(document.json().info.title, "Cat.Demo.PaymentProvider | v1");
});

test("a setting that is not valid fails at once", () => {
  assert.throws(() => readSettings({ FAILURE_ERROR_PERCENTAGE: "101" }), /FAILURE_ERROR_PERCENTAGE/);
  assert.throws(() => readSettings({ FAILURE_OUTAGE: "maybe" }), /FAILURE_OUTAGE/);
});
