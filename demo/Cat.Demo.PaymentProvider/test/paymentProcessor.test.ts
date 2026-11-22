import assert from "node:assert/strict";
import { test } from "node:test";
import { ChargeStatuses, RefundStatuses } from "../src/models.ts";
import { PaymentProcessor } from "../src/paymentProcessor.ts";
import type { FailureSettings } from "../src/settings.ts";

const off: FailureSettings = { latencyMs: 0, errorPercentage: 0, outage: false };

function processor(failures: Partial<FailureSettings> = {}, nextPercentage: () => number = () => 0) {
  return new PaymentProcessor({ ...off, ...failures }, nextPercentage);
}

test("an amount up to the maximum is approved with a reference", async () => {
  const outcome = await processor().charge("key-1", { orderNumber: "20261106-0001", amount: 500 });

  assert.ok(!outcome.failed);
  assert.equal(outcome.response.status, ChargeStatuses.approved);
  assert.match(outcome.response.reference ?? "", /^PAY-20261106-0001-/);
});

test("an amount above the maximum is declined without a reference", async () => {
  const outcome = await processor().charge("key-1", { orderNumber: "20261106-0001", amount: 500.01 });

  assert.ok(!outcome.failed);
  assert.deepEqual(outcome.response, { status: ChargeStatuses.declined, reference: null });
});

test("the same idempotency key gets the same answer and is charged once", async () => {
  const payments = processor();

  const first = await payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 });
  const second = await payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 });

  assert.deepEqual(second, first);
  assert.equal(payments.charges, 1);
});

test("an outage fails and takes nothing", async () => {
  const payments = processor({ outage: true });

  const outcome = await payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 });

  assert.ok(outcome.failed);
  assert.equal(payments.charges, 0);
});

test("a random failure fails after the charge and the retry does not charge again", async () => {
  let next = 10;
  const payments = processor({ errorPercentage: 50 }, () => next);

  const failed = await payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 });

  assert.ok(failed.failed);
  assert.equal(payments.charges, 1, "The money was taken before the failure.");

  // The number is now above the limit, so the retry gets through and finds the stored answer.
  next = 90;
  const retry = await payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 });

  assert.ok(!retry.failed);
  assert.equal(retry.response.status, ChargeStatuses.approved);
  assert.equal(payments.charges, 1);
});

test("a latency delays the answer on the timer", async (context) => {
  context.mock.timers.enable({ apis: ["setTimeout"] });
  const payments = processor({ latencyMs: 30_000 });

  let done = false;
  const answer = payments.charge("key-1", { orderNumber: "20261106-0001", amount: 10 }).then((outcome) => {
    done = true;
    return outcome;
  });

  await Promise.resolve();
  assert.equal(done, false, "The answer waits for the latency.");

  context.mock.timers.tick(30_000);
  const outcome = await answer;

  assert.ok(!outcome.failed);
});

test("a refund of an approved charge gives the money back", async () => {
  const payments = processor();
  await payments.charge("charge-1", { orderNumber: "20261106-0001", amount: 10 });

  const outcome = await payments.refund("refund-1", { orderNumber: "20261106-0001" });

  assert.deepEqual(outcome, { failed: false, response: { status: RefundStatuses.refunded } });
});

test("a refund of a declined or an unknown order says there is nothing to refund", async () => {
  const payments = processor();
  await payments.charge("charge-1", { orderNumber: "20261106-0001", amount: 500.01 });

  const declined = await payments.refund("refund-1", { orderNumber: "20261106-0001" });
  const unknown = await payments.refund("refund-2", { orderNumber: "20261106-0002" });

  assert.ok(!declined.failed && declined.response.status === RefundStatuses.nothingToRefund);
  assert.ok(!unknown.failed && unknown.response.status === RefundStatuses.nothingToRefund);
});

test("the same refund key gets the same answer and is refunded once", async () => {
  const payments = processor();
  await payments.charge("charge-1", { orderNumber: "20261106-0001", amount: 10 });

  const first = await payments.refund("refund-1", { orderNumber: "20261106-0001" });
  const second = await payments.refund("refund-1", { orderNumber: "20261106-0001" });

  assert.deepEqual(second, first);
  assert.equal(payments.refunds, 1);
});

test("an outage fails a refund too", async () => {
  const outcome = await processor({ outage: true }).refund("refund-1", { orderNumber: "20261106-0001" });

  assert.ok(outcome.failed);
});
