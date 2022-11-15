#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Order/Dev.Order.API/Dev.Services.Order.API.csproj", "Services/Order/Dev.Order.API/"]
COPY ["Shared/Dev.Shared/Dev.Shared.csproj", "Shared/Dev.Shared/"]
COPY ["Services/Order/Dev.Services.Order.Application/Dev.Services.Order.Application.csproj", "Services/Order/Dev.Services.Order.Application/"]
COPY ["Services/Order/Dev.Services.Order.Domain/Dev.Services.Order.Domain.csproj", "Services/Order/Dev.Services.Order.Domain/"]
COPY ["Services/Order/Dev.Services.Order.Domain.Core/Dev.Services.Order.Domain.Core.csproj", "Services/Order/Dev.Services.Order.Domain.Core/"]
COPY ["Services/Order/Dev.Services.Order.Infrastructure/Dev.Services.Order.Infrastructure.csproj", "Services/Order/Dev.Services.Order.Infrastructure/"]
RUN dotnet restore "Services/Order/Dev.Order.API/Dev.Services.Order.API.csproj"
COPY . .
WORKDIR "/src/Services/Order/Dev.Order.API"
RUN dotnet build "Dev.Services.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dev.Services.Order.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dev.Services.Order.API.dll"]