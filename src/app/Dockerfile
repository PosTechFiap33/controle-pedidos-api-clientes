
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CP.Clientes/adapter/driver/CP.Clientes.Api/CP.Clientes.Api.csproj", "CP.Clientes/adapter/driver/CP.Clientes.Api/"]
COPY ["CP.Clientes/adapter/CP.Clientes.IOC/CP.Clientes.IOC.csproj", "CP.Clientes/adapter/CP.Clientes.IOC/"]
COPY ["CP.Clientes/core/CP.Clientes.Application/CP.Clientes.Application.csproj", "CP.Clientes/core/CP.Clientes.Application/"]
COPY ["CP.Clientes/core/CP.Clientes.Domain/CP.Clientes.Domain.csproj", "CP.Clientes/core/CP.Clientes.Domain/"]
COPY ["CP.Clientes/adapter/driven/CP.Clientes.Payment/CP.Clientes.Payment.csproj", "CP.Clientes/adapter/driven/CP.Clientes.Payment/"]
COPY ["CP.Clientes/adapter/driven/CP.Clientes.Infra/CP.Clientes.Infra.csproj", "CP.Clientes/adapter/driven/CP.Clientes.Infra/"]
RUN dotnet restore "CP.Clientes/adapter/driver/CP.Clientes.Api/CP.Clientes.Api.csproj"
COPY . .
WORKDIR "/src/CP.Clientes/adapter/driver/CP.Clientes.Api"
RUN dotnet build "CP.Clientes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CP.Clientes.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CP.Clientes.Api.dll"]
