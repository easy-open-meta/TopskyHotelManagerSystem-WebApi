#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.WebApi/EOM.TSHotelManager.WebApi.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.WebApi/"]
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Shared/EOM.TSHotelManager.Shared.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Shared/"]
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Application/EOM.TSHotelManager.Application.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Application/"]
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Common.Core/EOM.TSHotelManager.Common.Core.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Common.Core/"]
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Common.Util/EOM.TSHotelManager.Common.Util.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.Common.Util/"]
COPY ["topsky-hotel-manager-system-web-api/EOM.TSHotelManager.EntityFramework/EOM.TSHotelManager.EntityFramework.csproj", "topsky-hotel-manager-system-web-api/EOM.TSHotelManager.EntityFramework/"]
RUN dotnet restore "./topsky-hotel-manager-system-web-api/EOM.TSHotelManager.WebApi/EOM.TSHotelManager.WebApi.csproj"
COPY . .
WORKDIR "/src/topsky-hotel-manager-system-web-api/EOM.TSHotelManager.WebApi"
RUN dotnet build "./EOM.TSHotelManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EOM.TSHotelManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EOM.TSHotelManager.WebApi.dll"]