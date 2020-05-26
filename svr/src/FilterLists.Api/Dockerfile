#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["./FilterLists.Api"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /app/src
COPY ["src/FilterLists.Application/FilterLists.Application.csproj", "FilterLists.Application/"]
COPY ["src/FilterLists.Domain/FilterLists.Domain.csproj", "FilterLists.Domain/"]
COPY ["src/FilterLists.Infrastructure/FilterLists.Infrastructure.csproj", "FilterLists.Infrastructure/"]
COPY ["src/FilterLists.Infrastructure.Migrations/FilterLists.Infrastructure.Migrations.csproj", "FilterLists.Infrastructure.Migrations/"]
WORKDIR "/app/src/FilterLists.Api"
COPY ["src/FilterLists.Api/FilterLists.Api.csproj", "."]
RUN dotnet restore

WORKDIR /app/src
COPY ["src/FilterLists.Application/.", "FilterLists.Application/"]
COPY ["src/FilterLists.Domain/.", "FilterLists.Domain/"]
COPY ["src/FilterLists.Infrastructure/.", "FilterLists.Infrastructure/"]
COPY ["src/FilterLists.Infrastructure.Migrations/.", "FilterLists.Infrastructure.Migrations/"]
WORKDIR "/app/src/FilterLists.Api"
COPY ["src/FilterLists.Api/.", "."]
RUN dotnet build -c Release -r linux-musl-x64 --no-restore

FROM build AS publish
RUN dotnet publish -c Release -r linux-musl-x64 --no-restore --no-build -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .