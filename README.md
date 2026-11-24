# DeliveryRoundsApi

An ASP.NET Core Web API for delivery drivers to manage their delivery rounds: create rounds, add stops (addresses) and mark each stop as delivered or failed.

I designed and built this as my capstone project for the course Application Development at Odisee (2026–2027), from the project proposal to the code.

## Features

- **Rounds and stops**: a one-to-many data model. Each round has a maximum number of stops.
- **Business rules in the service layer**: a stop can't be added to a full round (`409 Conflict`), and a username must be unique (`409 Conflict`).
- **Validation** on all input DTOs (`400 Bad Request`).
- **JWT authentication**: register and log in to get a token. Reading rounds and stops is open; creating, updating and deleting require a valid token (`401 Unauthorized` without one).
- **Hashed passwords** with ASP.NET Core `PasswordHasher<User>`.
- The username from the token is stored as `CreatedBy` on every new stop.
- **Seed data** for four rounds and seven stops, so the business rules can be tested right away.

## Architecture

```
Controllers  →  Services (business rules)  →  Repositories (data access)  →  EF Core / SQLite
     ↑
    DTOs + mappings
```

## Endpoints

| Endpoint | Description | Auth |
|---|---|---|
| `POST /auth/register` | Register a user | No |
| `POST /auth/login` | Log in, returns a JWT | No |
| `GET /rounds` | All rounds | No |
| `GET /rounds/{id}` | One round with its stops | No |
| `POST /rounds` | Create a round | Yes |
| `PUT /rounds/{id}` | Update a round | Yes |
| `DELETE /rounds/{id}` | Delete a round | Yes |
| `GET /rounds/{id}/stops` | Stops of a round | No |
| `POST /rounds/{id}/stops` | Add a stop to a round | Yes |
| `DELETE /stops/{id}` | Delete a stop | Yes |

## Tech stack

C# · .NET 10 · ASP.NET Core Web API · Entity Framework Core · SQLite · JWT Bearer authentication

## Getting started

Requirements: .NET 10 SDK and the EF Core tools (`dotnet tool install --global dotnet-ef`).

```bash
cd DeliveryRoundsApi

# Set a JWT signing key of at least 32 characters (kept out of the repo)
dotnet user-secrets set "Jwt:Key" "<a-random-string-of-at-least-32-characters>"

# Create the database and start the API
dotnet ef database update
dotnet run
```

The database is seeded on first start. Use `DeliveryRoundsApi.http` to try the endpoints: register, log in, then paste the token into `@token`.
