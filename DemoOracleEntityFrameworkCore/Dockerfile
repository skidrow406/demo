FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
COPY DemoOracleEntityFrameworkCore/DemoOracleEntityFrameworkCore.csproj .
RUN dotnet restore DemoOracleEntityFrameworkCore.csproj -r linux-musl-x64
COPY DemoOracleEntityFrameworkCore/ .
# Fix vấn đề trên Debian 10: https://github.com/dotnet/dotnet-docker/issues/2470
ENV COMPlus_EnableDiagnostics=0
# self-contained false nếu dùng mcr.microsoft.com/dotnet/aspnet ở bước tiếp theo
RUN dotnet publish DemoOracleEntityFrameworkCore.csproj -p:PublishSingleFile=true -r linux-musl-x64 --self-contained true -p:PublishTrimmed=True -p:TrimMode=Link -c release -o /app/publish --no-restore

# Có thể dùng mcr.microsoft.com/dotnet/aspnet
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine-amd64
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["/app/DemoOracleEntityFrameworkCore"]