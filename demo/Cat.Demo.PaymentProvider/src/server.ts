import { buildApp } from "./app.ts";
import { readSettings } from "./settings.ts";

// A setting that is not valid fails here, so the AppHost shows the problem when it starts.
const settings = readSettings();
const app = await buildApp(settings, { logger: true });

// The name localhost covers both the IPv4 and the IPv6 address, so the shop reaches the provider either way.
await app.listen({ port: settings.port, host: "localhost" });
