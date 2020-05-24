#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["FilterLists.Api/FilterLists.Api.csproj", "FilterLists.Api/"]
COPY ["FilterLists.Infrastructure/FilterLists.Infrastructure.csproj", "FilterLists.Infrastructure/"]
COPY ["FilterLists.Domain/FilterLists.Domain.csproj", "FilterLists.Domain/"]
COPY ["FilterLists.Application/FilterLists.Application.csproj", "FilterLists.Application/"]
RUN dotnet restore "FilterLists.Api/FilterLists.Api.csproj"
COPY . .
WORKDIR "/src/FilterLists.Api"
RUN dotnet build "FilterLists.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilterLists.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilterLists.Api.dll"]