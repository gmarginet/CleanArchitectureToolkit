// The settings of the provider. They come from environment variables, the way a Node.js API is configured.

export type FailureSettings = {
  // Waits this many milliseconds before every answer. Zero means no delay.
  latencyMs: number;
  // The share of calls, from 0 to 100, that fail after the payment is already taken.
  // The caller gets an error and tries again. This is the case the idempotency key protects against.
  errorPercentage: number;
  // When true, every call fails at once and nothing is taken.
  outage: boolean;
};

export type Settings = {
  apiKey: string;
  port: number;
  failures: FailureSettings;
};

// Reads the settings and throws on a value that is not valid, so the provider does not start with a wrong one.
export function readSettings(env: NodeJS.ProcessEnv = process.env): Settings {
  return {
    apiKey: env.PROVIDER_API_KEY ?? "demo-provider-key",
    port: readNumber(env, "PORT", 5103, 1, 65535),
    failures: {
      latencyMs: readNumber(env, "FAILURE_LATENCY_MS", 0, 0, Number.MAX_SAFE_INTEGER),
      errorPercentage: readNumber(env, "FAILURE_ERROR_PERCENTAGE", 0, 0, 100),
      outage: readBoolean(env, "FAILURE_OUTAGE", false),
    },
  };
}

function readNumber(env: NodeJS.ProcessEnv, name: string, fallback: number, min: number, max: number): number {
  const text = env[name];
  if (text === undefined || text.trim() === "") {
    return fallback;
  }

  const value = Number(text);
  if (!Number.isInteger(value) || value < min || value > max) {
    throw new Error(`${name} must be a whole number from ${min} to ${max}, but it is '${text}'.`);
  }

  return value;
}

function readBoolean(env: NodeJS.ProcessEnv, name: string, fallback: boolean): boolean {
  const text = env[name]?.trim().toLowerCase();
  if (text === undefined || text === "") {
    return fallback;
  }

  if (text === "true") {
    return true;
  }

  if (text === "false") {
    return false;
  }

  throw new Error(`${name} must be true or false, but it is '${env[name]}'.`);
}
