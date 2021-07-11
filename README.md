# Catalog API - Example dotnet code

## Run

$ dotnet run

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
$ dotnet add package MongoDB.Driver
```

- Sync/Async Task Operation
- Secret Management

```sh
$ dotnet user-secrets init
$ dotnet user-secrets set MongoDbSettings:Password password
```

- Health checks liveness/readiness

```sh
$ dotnet add package AspNetCore.HealthChecks.MongoDb
```

- Custom health check

Unhealthy

```sh
$ docker pause mongo
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
$ docker unpause mongo
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

- Deployment

```sh
$ docker build -t catalog:v1 .
$ docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=password catalog:v1
```

Publish Docker Image

```sh
$ docker tag <image>:<tag> <target-image>:<tag>
$ docker push <hub-user>/<repo-name>:<tag>
```

Create Secret and apply kubernetes deployment

```sh
$ kubectl create secret generic catalog-secrets --from-literal=mongodb-password='password'
$ kubectl apply -f kubernetes
```

Start Tunnel

```sh
$ minikube tunnel
Status:
	machine: minikube
	pid: 22554
	route: 10.96.0.0/12 -> 192.168.64.3
	minikube: Running
	services: [nginx-ils-service]
    errors:
		minikube: no errors
		router: no errors
		loadbalancer emulator: no errors


$ kubectl get svc

NAME              TYPE           CLUSTER-IP       EXTERNAL-IP      PORT(S)        AGE
catalog-service   LoadBalancer   10.102.211.121   10.102.211.121   80:30816/TCP   31m
kubernetes        ClusterIP      10.96.0.1        <none>           443/TCP        104d
mongo-service     ClusterIP      None             <none>           27017/TCP      18m
mongodb-service   ClusterIP      None             <none>           27017/TCP      8m23s

curl 10.102.211.121/health/live
```
