#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/GenericImporter.API/GenericImporter.API.csproj", "src/GenericImporter.API/"]
COPY ["src/GenericImporter.Infra.CrossCutting.IoC/GenericImporter.Infra.CrossCutting.IoC.csproj", "src/GenericImporter.Infra.CrossCutting.IoC/"]
COPY ["src/GenericImporter.Application/GenericImporter.Application.csproj", "src/GenericImporter.Application/"]
COPY ["src/GenericImporter.Application.Core/GenericImporter.Application.Core.csproj", "src/GenericImporter.Application.Core/"]
COPY ["src/GenericImporter.Domain.Core/GenericImporter.Domain.Core.csproj", "src/GenericImporter.Domain.Core/"]
COPY ["src/GenericImporter.Domain/GenericImporter.Domain.csproj", "src/GenericImporter.Domain/"]
COPY ["src/GenericImporter.Infra.Data/GenericImporter.Infra.Data.csproj", "src/GenericImporter.Infra.Data/"]
COPY ["src/GenericImporter.Infra.Data.Core/GenericImporter.Infra.Data.Core.csproj", "src/GenericImporter.Infra.Data.Core/"]
COPY ["src/GenericImporter.Web.Core/GenericImporter.Web.Core.csproj", "src/GenericImporter.Web.Core/"]
RUN dotnet restore "src/GenericImporter.API/GenericImporter.API.csproj"
COPY . .
WORKDIR "/src/src/GenericImporter.API"
RUN dotnet build "GenericImporter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericImporter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GenericImporter.API.dll"]