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
- Sync/Async Task Operation
- Secret Management
