FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-amd64 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Dev.Shared/*.csproj Shared/Dev.Shared/
COPY Services/FakePayment/Dev.Services.FakePayment/*.csproj Services/FakePayment/Dev.Services.FakePayment/
RUN dotnet restore Services/FakePayment/Dev.Services.FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/Dev.Services.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-amd64 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Dev.Services.FakePayment.dll" ]