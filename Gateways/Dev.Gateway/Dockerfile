#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gateways/Dev.Gateway/Dev.Gateway.csproj", "Gateways/Dev.Gateway/"]
RUN dotnet restore "Gateways/Dev.Gateway/Dev.Gateway.csproj"
COPY . .
WORKDIR "/src/Gateways/Dev.Gateway"
RUN dotnet build "Dev.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dev.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dev.Gateway.dll"]