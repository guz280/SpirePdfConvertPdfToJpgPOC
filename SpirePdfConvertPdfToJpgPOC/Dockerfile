#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
    && rm -rf /var/lib/apt/lists/*
COPY ["SpirePdfConvertPdfToJpgPOC/SpirePdfConvertPdfToJpgPOC.csproj", "SpirePdfConvertPdfToJpgPOC/"]
RUN dotnet restore "SpirePdfConvertPdfToJpgPOC/SpirePdfConvertPdfToJpgPOC.csproj"
COPY . .
WORKDIR "/src/SpirePdfConvertPdfToJpgPOC"
RUN dotnet build "SpirePdfConvertPdfToJpgPOC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpirePdfConvertPdfToJpgPOC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpirePdfConvertPdfToJpgPOC.dll"]