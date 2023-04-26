#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinTrabajo/MinTrabajo.csproj", "MinTrabajo/"]
COPY ["MinTrabajo.Aplicaciones/MinTrabajo.Aplicaciones.csproj", "MinTrabajo.Aplicaciones/"]
COPY ["MinTrabajo.Datos/MinTrabajo.Datos.csproj", "MinTrabajo.Datos/"]
COPY ["MinTrabajo.Dominio/MinTrabajo.Dominio.csproj", "MinTrabajo.Dominio/"]
RUN dotnet restore "MinTrabajo/MinTrabajo.csproj"
COPY . .
WORKDIR "/src/MinTrabajo"
RUN dotnet build "MinTrabajo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinTrabajo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinTrabajo.dll"]