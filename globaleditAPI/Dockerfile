FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY globaleditAPI/CorcoranAPI.csproj globaleditAPI/
RUN dotnet restore globaleditAPI/CorcoranAPI.csproj
COPY . .
WORKDIR /src/globaleditAPI
RUN dotnet build CorcoranAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CorcoranAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CorcoranAPI.dll"]
