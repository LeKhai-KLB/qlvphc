#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/CatalogService/CatalogService.API/CatalogService.API.csproj", "Services/CatalogService/CatalogService.API/"]
COPY ["BuildingBlocks/Common.Logging/Common.Logging.csproj", "BuildingBlocks/Common.Logging/"]
COPY ["Services/CatalogService/CatalogService.Application/CatalogService.Application.csproj", "Services/CatalogService/CatalogService.Application/"]
COPY ["BuildingBlocks/Contracts/Contracts.csproj", "BuildingBlocks/Contracts/"]
COPY ["BuildingBlocks/Infrastructure/Infrastructure.csproj", "BuildingBlocks/Infrastructure/"]
COPY ["BuildingBlocks/Shared/Shared.csproj", "BuildingBlocks/Shared/"]
COPY ["Services/CatalogService/CatalogService.Domain/CatalogService.Domain.csproj", "Services/CatalogService/CatalogService.Domain/"]
COPY ["Services/CatalogService/CatalogService.Infrastructure/CatalogService.Infrastructure.csproj", "Services/CatalogService/CatalogService.Infrastructure/"]
RUN dotnet restore "./Services/CatalogService/CatalogService.API/./CatalogService.API.csproj"
COPY . .
WORKDIR "/src/Services/CatalogService/CatalogService.API"
RUN dotnet build "./CatalogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CatalogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.API.dll"]