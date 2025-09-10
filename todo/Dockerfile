# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# 1 Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera csproj och återställ beroenden
COPY api-service/ToDoAPI.csproj ./api-service/
RUN dotnet restore ./api-service/ToDoAPI.csproj

# Kopiera resten av koden
COPY api-service ./api-service
COPY todoFile.txt ./api-service/todoFile.txt

# Bygg och publicera
WORKDIR /src/api-service
RUN dotnet publish ToDoAPI.csproj -c Release -o /app/publish 

# 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final 
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /api-service/todoFile.txt ./todoFile.txt

ENTRYPOINT ["dotnet", "ToDoAPI.dll"]