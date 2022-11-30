#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App
COPY . ./
RUN dotnet restore "SpirePdfConvertPdfToJpgPOC/SpirePdfConvertPdfToJpgPOC.csproj"
RUN dotnet publish "SpirePdfConvertPdfToJpgPOC/SpirePdfConvertPdfToJpgPOC.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0
RUN groupadd -g 1000 -r noviadmin && useradd --no-log-init -u 1000 -r -g noviadmin noviadmin
WORKDIR /App
COPY --from=build-env /App/out .
RUN chown -R noviadmin:noviadmin /App
USER noviadmin
ENTRYPOINT ["dotnet", "SpirePdfConvertPdfToJpgPOC.dll"]