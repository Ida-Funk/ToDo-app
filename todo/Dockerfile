# 1 Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera csproj och återställ beroenden (bättre caching)
COPY api-service/ToDoAPI.csproj ./api-service/
RUN dotnet restore ./api-service/ToDoAPI.csproj

# Kopiera resten av koden
COPY api-service ./api-service
COPY todoFile.txt ./todoFile.txt

## Bygg och publicera
WORKDIR /src/api-service
RUN dotnet publish ToDoAPI.csproj -c Release -o /app/publish
ida.

# 2 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy app
COPY --from=build /app/publish .

# projekt-lokal källa (Dockerfile i api-service/)
COPY --from=build /src/todoFile.txt ./todoFile.txt


ENV TODO_FILE_PATH=/app/todoFile.txt
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ToDoAPI.dll"]