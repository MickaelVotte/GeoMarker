# syntax=docker/dockerfile:1
FROM --platform=$BUILDPLATFORM dhi.io/dotnet:8.0-sdk AS build

COPY . /source

WORKDIR /source/ApiGeoMarker

# Leverage cache mount for NuGet packages
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

# Build and publish
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c Release --no-restore -o /app/publish

# Runtime stage
FROM dhi.io/aspnetcore:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

# Health check for orchestration
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

# Security: run as non-root user
USER $APP_UID

ENTRYPOINT ["dotnet", "GeoMarker.Api.dll"]
