---
name: cat-add-endpoint
description: Map a Clean Architecture Toolkit service request to a minimal API endpoint, with the response types listed. Use when the developer wants to expose a use case over HTTP, add a route, or says "add an endpoint".
---

# Add an endpoint

An endpoint maps one service request to an HTTP route with `Cat.Minimal.Api`. The template of the service already has an endpoints file with an example.

## Before you start
1. Find the service and its `Api` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Map a service request", "Choose the response types" and "Name your endpoints" in the readme of `Cat.Minimal.Api`. The readme is `modules/Cat.Minimal.Api/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.minimal.api/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask which service request to expose, the HTTP method and the route. Check that the request exists. When it does not, use `cat-add-service-request` first.
2. Open the endpoints file of the `Api` project, `Extensions/<Service>Endpoints.cs`. Follow the line of the example endpoint, and add one line for the new request, with the method that fits the HTTP verb: `MapCatGet`, `MapCatGetList`, `MapCatGetPagedList`, `MapCatPost`, `MapCatPut`, `MapCatPatch` or `MapCatDelete`. Do not create a new file for it.
3. List the response types the endpoint can return, as the chapter "Choose the response types" says, so the OpenAPI description is true. Give the endpoint a name.
4. The example endpoint has no authorization policy. Ask the developer who may call the new endpoint, and say so when a write endpoint stays open. The readme of `Cat.Minimal.Api` and the gateway decide how.
5. Run `dotnet build`. Run the service and call the endpoint when the developer wants it. The `.http` file of the Api project shows how.
6. Say what to do next, such as `cat-add-validator` for the rules of the request.

## Rules
- No logic in the endpoint. It maps the request and the response.
- A template writes files, and this skill only edits the endpoints file that the service template made.
