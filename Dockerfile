FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["HomeApi.csproj", ""]
RUN dotnet restore "/HomeApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "HomeApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HomeApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HomeApi.dll"]