FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["cinima-mgr.csproj", "./"]
RUN dotnet restore "cinima-mgr.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "cinima-mgr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cinima-mgr.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cinima-mgr.dll"]
