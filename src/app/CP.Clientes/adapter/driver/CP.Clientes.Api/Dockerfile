#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["adapter/driver/CP.Clientes.Api/CP.Clientes.Api.csproj", "adapter/driver/CP.Clientes.Api/"]
COPY ["adapter/CP.Clientes.IOC/CP.Clientes.IOC.csproj", "adapter/CP.Clientes.IOC/"]
COPY ["core/CP.Clientes.Application/CP.Clientes.Application.csproj", "core/CP.Clientes.Application/"]
COPY ["core/CP.Clientes.Domain/CP.Clientes.Domain.csproj", "core/CP.Clientes.Domain/"]
COPY ["common/CP.Clientes.CrossCutting/CP.Clientes.CrossCutting.csproj", "common/CP.Clientes.CrossCutting/"]
COPY ["adapter/driven/CP.Clientes.Infra/CP.Clientes.Infra.csproj", "adapter/driven/CP.Clientes.Infra/"]
RUN dotnet restore "adapter/driver/CP.Clientes.Api/CP.Clientes.Api.csproj"
COPY . .
WORKDIR "/src/adapter/driver/CP.Clientes.Api"
RUN dotnet build "CP.Clientes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CP.Clientes.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CP.Clientes.Api.dll"]
