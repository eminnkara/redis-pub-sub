FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisPubSub.Subscriber/RedisPubSub.Subscriber.csproj", "RedisPubSub.Subscriber/"]
RUN dotnet restore "RedisPubSub.Subscriber/RedisPubSub.Subscriber.csproj"
COPY . .
WORKDIR "/src/RedisPubSub.Subscriber"
RUN dotnet build "RedisPubSub.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisPubSub.Subscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisPubSub.Subscriber.dll"]
