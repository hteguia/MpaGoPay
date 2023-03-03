#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MpaGoPay.Server/MpaGoPay.Server.csproj", "MpaGoPay.Server/"]
RUN dotnet restore "MpaGoPay.Server/MpaGoPay.Server.csproj"
COPY . .
WORKDIR "/src/MpaGoPay.Server"
RUN dotnet build "MpaGoPay.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MpaGoPay.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MpaGoPay.Server.dll"]