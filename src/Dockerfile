# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY *.sln .
COPY src/FraudEngine.Api/*.csproj ./FraudEngine.Api/
RUN dotnet restore FraudEngine.Api/FraudEngine.Api.csproj
COPY src/FraudEngine.Api/. ./FraudEngine.Api/
WORKDIR /app/FraudEngine.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FraudEngine.Api.dll"]
