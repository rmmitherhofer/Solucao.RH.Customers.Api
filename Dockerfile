#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Solucao.RH.Customers.Api/Solucao.RH.Customers.Api.csproj", "src/Solucao.RH.Customers.Api/"]
COPY ["src/Solucao.RH.Customers.Business/Solucao.RH.Customers.Business.csproj", "src/Solucao.RH.Customers.Business/"]
COPY ["src/Solucao.RH.Customers.Data/Solucao.RH.Customers.Data.csproj", "src/Solucao.RH.Customers.Data/"]


RUN dotnet restore "./src/Solucao.RH.Customers.Api/Solucao.RH.Customers.Api.csproj"
COPY . .
WORKDIR "/src/src/Solucao.RH.Customers.Api"
RUN dotnet build "./Solucao.RH.Customers.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Solucao.RH.Customers.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Solucao.RH.Customers.Api.dll"]