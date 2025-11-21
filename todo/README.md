## Running
Start docker container: 
`docker build -t todoapi .`
`docker run --rm -p 8080:8080 -e ASPNETCORE_URLS=http://+:8080 todoapi`

Run local, without docker:
`dotnet run --project api-service/ToDoAPI.csproj --urls "http://localhost:5000"`

Call a function:
``

Postman:
..


## Improvements
AWS 
Lambda functions
DB
Frontend