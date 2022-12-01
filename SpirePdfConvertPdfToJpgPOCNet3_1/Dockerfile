#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /app
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
    && rm -rf /var/lib/apt/lists/*
COPY ["SpirePdfConvertPdfToJpgPOCNet3_1/SpirePdfConvertPdfToJpgPOCNet3_1.csproj", "SpirePdfConvertPdfToJpgPOCNet3_1/"]
RUN dotnet restore "SpirePdfConvertPdfToJpgPOCNet3_1/SpirePdfConvertPdfToJpgPOCNet3_1.csproj"
COPY . .
WORKDIR "/src/SpirePdfConvertPdfToJpgPOCNet3_1"
RUN dotnet build "SpirePdfConvertPdfToJpgPOCNet3_1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpirePdfConvertPdfToJpgPOCNet3_1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpirePdfConvertPdfToJpgPOCNet3_1.dll"]