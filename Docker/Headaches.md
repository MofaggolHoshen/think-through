# Docker problems and solves

## /src/DockerContainerBlazor/DockerContainerBlazor.csproj : error NU1301: Unable to load the service index for source <https://api.nuget.org/v3/index.json>

```CLI
 docker build -t blazorapp:1.0.0 . -f DockerContainerBlazor\Dockerfile --build-arg http_proxy=http://proxy.com:8080
```

## CSC : error CS5001: Program does not contain a static 'Main' method suitable for an entry point

This error is missleading, the main error is in `COPY . .` where directory did not specified correrctly.

```YML
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Abc.csproj", "dirctory/"]
RUN dotnet restore "directory/Abc.csproj"
COPY . /src/directory #COPY . .
WORKDIR "/src/directory"
RUN dotnet build "Abc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Abc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Abc.dll"]
```
