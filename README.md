# Catalog API - Example dotnet code

## Run

dotnet run

### Require

```sh
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db \
-e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=password mongo
```

#### You will learn

- MVC
- DTO
- Integrate MongoDB

```sh
dotnet add package MongoDB.Driver
```

- Sync/Async Task Operation
- Secret Management

```sh
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password password
```

- Health checks liveness/readiness

```sh
dotnet add package AspNetCore.HealthChecks.MongoDb
```

- Custom health check

Unhealthy

```sh
docker pause mongo
```

```json
{
  "status": "Unhealthy",
  "checks": [
    {
        "name": "mongodb",
        "status": "Unhealthy",
        "exception": "The operation was canceled.",
        "duration": "00:00:03.0196882"
    }
  ]
}
```

Healthy

```sh
docker unpause mongo
```

```json
{
  "status": "Healthy",
  "checks": [
    {
        "name": "mongodb",
        "status": "Healthy",
        "exception": "none",
        "duration": "00:00:00.0019597"
    }
  ]
}
```
