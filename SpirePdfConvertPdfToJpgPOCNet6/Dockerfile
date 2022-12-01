#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
# install System.Drawing native dependencies
RUN apt-get update \
   && apt-get install -y --allow-unauthenticated \
       libc6-dev \
       libgdiplus \
       libx11-dev \
    && rm -rf /var/lib/apt/lists/*
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 
WORKDIR /src
# install System.Drawing native dependencies
RUN apt-get update \
   && apt-get install -y --allow-unauthenticated \
       libc6-dev \
       libgdiplus \
       libx11-dev \
    && rm -rf /var/lib/apt/lists/*
COPY ["SpirePdfConvertPdfToJpgPOCNet6/SpirePdfConvertPdfToJpgPOCNet6.csproj", "SpirePdfConvertPdfToJpgPOCNet6/"]
RUN dotnet restore "SpirePdfConvertPdfToJpgPOCNet6/SpirePdfConvertPdfToJpgPOCNet6.csproj"
COPY . .
WORKDIR "/src/SpirePdfConvertPdfToJpgPOCNet6"
RUN dotnet build "SpirePdfConvertPdfToJpgPOCNet6.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "SpirePdfConvertPdfToJpgPOCNet6.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpirePdfConvertPdfToJpgPOCNet6.dll"]