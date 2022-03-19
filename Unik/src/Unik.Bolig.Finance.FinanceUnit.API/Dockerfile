#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Unik.Bolig.Finance.FinanceUnit.API/Unik.Bolig.Finance.FinanceUnit.API.csproj", "Unik.Bolig.Finance.FinanceUnit.API/"]
COPY ["Unik.Bolig.Finance.FinanceUnit.Domain/Unik.Bolig.Finance.FinanceUnit.Domain.csproj", "Unik.Bolig.Finance.FinanceUnit.Domain/"]
COPY ["Unik.Bolig.Finance.FinanceUnit.Infrastructure/Unik.Bolig.Finance.FinanceUnit.Infrastructure.csproj", "Unik.Bolig.Finance.FinanceUnit.Infrastructure/"]
RUN dotnet restore "Unik.Bolig.Finance.FinanceUnit.API/Unik.Bolig.Finance.FinanceUnit.API.csproj"
COPY . .
WORKDIR "/src/Unik.Bolig.Finance.FinanceUnit.API"
RUN dotnet build "Unik.Bolig.Finance.FinanceUnit.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unik.Bolig.Finance.FinanceUnit.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unik.Bolig.Finance.FinanceUnit.API.dll"]