Will have a closer look at the server behaviour of JabbR and see if i can diagnose it locally, hoping its something glaring.

## Repro steps

- Open sln, build and run
- User should receive a HTTP 500 response on the "/nick {username} {password}" invoke.
- If that succeeds, the user should receive a "Use '/join room' to join a room" response on the say invoke (this is after joining successfully)

## Environment details

SignalR.Client built from this version, includes pdbs: https://github.com/SignalR/SignalR/commit/585cded973c0d4db57a1d0adcecb7f9d694a8fda

Jabbot source included so that you can step through code.

