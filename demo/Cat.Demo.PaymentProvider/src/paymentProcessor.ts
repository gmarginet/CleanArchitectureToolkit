import { randomInt, randomUUID } from "node:crypto";
import {
  ChargeStatuses,
  RefundStatuses,
  type ChargeRequest,
  type ChargeResponse,
  type Outcome,
  type RefundRequest,
  type RefundResponse,
} from "./models.ts";
import type { FailureSettings } from "./settings.ts";

// The rules of the stand-in for an outside payment provider: an amount above MaximumAmount euro is declined, the rest is approved.
// It remembers the answer for every idempotency key, so a repeated call gets the first answer and charges nothing twice.
// The failure settings are applied around that. Payments and refunds live in memory.
export const MaximumAmount = 500;

export class PaymentProcessor {
  readonly #charges = new Map<string, ChargeResponse>();
  readonly #approvedOrders = new Set<string>();
  readonly #refunds = new Map<string, RefundResponse>();
  readonly #failures: FailureSettings;
  readonly #nextPercentage: () => number;

  // nextPercentage gives a number from 0 to 99. A call fails when the number is below the error percentage.
  constructor(failures: FailureSettings, nextPercentage: () => number = () => randomInt(100)) {
    this.#failures = failures;
    this.#nextPercentage = nextPercentage;
  }

  // How many different charges were taken, one for every idempotency key.
  get charges(): number {
    return this.#charges.size;
  }

  // How many different refunds were done, one for every idempotency key.
  get refunds(): number {
    return this.#refunds.size;
  }

  // Takes a payment. The idempotency key makes a repeated call return the first answer.
  async charge(idempotencyKey: string, request: ChargeRequest): Promise<Outcome<ChargeResponse>> {
    // An outage fails at once and takes nothing.
    if (this.#failures.outage) {
      return { failed: true };
    }

    await this.#wait();

    // The payment is taken and remembered first. A random failure comes after it, which is the worst case:
    // the money is gone and the caller does not know. The retry finds the answer and charges nothing again.
    let response = this.#charges.get(idempotencyKey);
    if (response === undefined) {
      response = charge(request);
      this.#charges.set(idempotencyKey, response);
    }

    if (response.status === ChargeStatuses.approved) {
      this.#approvedOrders.add(request.orderNumber);
    }

    return this.#failsRandomly() ? { failed: true } : { failed: false, response };
  }

  // Gives the money of an approved payment back. The idempotency key makes a repeated call return the first answer.
  // An order that was declined or never charged has nothing to give back, and the answer says so.
  // The outage, latency and error settings apply as for a charge.
  // A random failure comes after the refund is remembered, so the retry gets the same answer.
  async refund(idempotencyKey: string, request: RefundRequest): Promise<Outcome<RefundResponse>> {
    if (this.#failures.outage) {
      return { failed: true };
    }

    await this.#wait();

    let response = this.#refunds.get(idempotencyKey);
    if (response === undefined) {
      response = {
        status: this.#approvedOrders.has(request.orderNumber) ? RefundStatuses.refunded : RefundStatuses.nothingToRefund,
      };
      this.#refunds.set(idempotencyKey, response);
    }

    return this.#failsRandomly() ? { failed: true } : { failed: false, response };
  }

  #wait(): Promise<void> {
    const { latencyMs } = this.#failures;
    return latencyMs > 0 ? new Promise((resolve) => setTimeout(resolve, latencyMs)) : Promise.resolve();
  }

  #failsRandomly(): boolean {
    return this.#failures.errorPercentage > 0 && this.#nextPercentage() < this.#failures.errorPercentage;
  }
}

function charge(request: ChargeRequest): ChargeResponse {
  return request.amount > MaximumAmount
    ? { status: ChargeStatuses.declined, reference: null }
    : { status: ChargeStatuses.approved, reference: `PAY-${request.orderNumber}-${randomUUID().replaceAll("-", "")}` };
}
