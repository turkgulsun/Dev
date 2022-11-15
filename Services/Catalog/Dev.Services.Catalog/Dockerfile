FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-amd64 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Dev.Shared/*.csproj Shared/Dev.Shared/
COPY Services/Catalog/Dev.Services.Catalog/*.csproj Services/Catalog/Dev.Services.Catalog/
RUN dotnet restore Services/Catalog/Dev.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/Dev.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-amd64 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Dev.Services.Catalog.dll" ]