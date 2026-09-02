FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY server/ ./server/
WORKDIR /src/server
RUN dotnet restore src/RiseOfReign.Api/RiseOfReign.Api.csproj
RUN dotnet publish src/RiseOfReign.Api/RiseOfReign.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
COPY data/epochs/1933 /app/content/1933
ENV ROR_EPOCH_1933_PATH=/app/content/1933
EXPOSE 8080
ENTRYPOINT ["dotnet", "RiseOfReign.Api.dll"]
