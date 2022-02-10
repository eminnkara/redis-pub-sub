FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisPubSub.SubscriberBar/RedisPubSub.SubscriberBar.csproj", "RedisPubSub.SubscriberBar/"]
RUN dotnet restore "RedisPubSub.SubscriberBar/RedisPubSub.SubscriberBar.csproj"
COPY . .
WORKDIR "/src/RedisPubSub.SubscriberBar"
RUN dotnet build "RedisPubSub.SubscriberBar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisPubSub.SubscriberBar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisPubSub.SubscriberBar.dll"]
