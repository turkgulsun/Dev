FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Dev.Shared/*.csproj Shared/Dev.Shared/
COPY IdentityServer/Dev.IdentityServer/*.csproj IdentityServer/Dev.IdentityServer/ 
RUN dotnet restore  IdentityServer/Dev.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/Dev.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Dev.IdentityServer.dll" ]