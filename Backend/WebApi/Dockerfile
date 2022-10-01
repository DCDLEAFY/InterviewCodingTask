FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base

WORKDIR /app
EXPOSE 5143

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

COPY ["WebApi.csproj", "./"]
RUN dotnet restore "./WebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish
FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebApi.dll"]