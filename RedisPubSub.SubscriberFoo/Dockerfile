FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisPubSub.SubscriberFoo/RedisPubSub.SubscriberFoo.csproj", "RedisPubSub.SubscriberFoo/"]
RUN dotnet restore "RedisPubSub.SubscriberFoo/RedisPubSub.SubscriberFoo.csproj"
COPY . .
WORKDIR "/src/RedisPubSub.SubscriberFoo"
RUN dotnet build "RedisPubSub.SubscriberFoo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisPubSub.SubscriberFoo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisPubSub.SubscriberFoo.dll"]
