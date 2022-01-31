FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["webapiApiService.csproj", "."]
RUN dotnet restore "webapiApiService.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "webapiApiService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapiApiService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapiApiService.dll"]