#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RegAndAuth/RegAndAuth.csproj", "RegAndAuth/"]
RUN dotnet restore "RegAndAuth/RegAndAuth.csproj"
COPY . .
WORKDIR "/src/RegAndAuth"
RUN dotnet build "RegAndAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RegAndAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RegAndAuth.dll"]