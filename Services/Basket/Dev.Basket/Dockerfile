FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-amd64 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Dev.Shared/*.csproj Shared/Dev.Shared/
COPY Services/Basket/Dev.Basket/*.csproj Services/Basket/Dev.Basket/
RUN dotnet restore Services/Basket/Dev.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/Dev.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-amd64 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Dev.Basket.dll" ]