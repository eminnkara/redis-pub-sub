FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisPubSub.Publisher/RedisPubSub.Publisher.csproj", "RedisPubSub.Publisher/"]
RUN dotnet restore "RedisPubSub.Publisher/RedisPubSub.Publisher.csproj"
COPY . .
WORKDIR "/src/RedisPubSub.Publisher"
RUN dotnet build "RedisPubSub.Publisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisPubSub.Publisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisPubSub.Publisher.dll"]
