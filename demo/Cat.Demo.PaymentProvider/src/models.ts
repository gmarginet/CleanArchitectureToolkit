// The shapes of the contract, see openapi.json. A decline is an answer, not an error.

export type ChargeRequest = { orderNumber: string; amount: number };

export type ChargeResponse = { status: ChargeStatus; reference: string | null };

export type RefundRequest = { orderNumber: string };

export type RefundResponse = { status: RefundStatus };

export const ChargeStatuses = { approved: "approved", declined: "declined" } as const;
export type ChargeStatus = (typeof ChargeStatuses)[keyof typeof ChargeStatuses];

export const RefundStatuses = { refunded: "refunded", nothingToRefund: "nothing_to_refund" } as const;
export type RefundStatus = (typeof RefundStatuses)[keyof typeof RefundStatuses];

// The outcome of a call: either an answer, or a failure that was switched on on purpose.
export type Outcome<T> = { failed: false; response: T } | { failed: true };
