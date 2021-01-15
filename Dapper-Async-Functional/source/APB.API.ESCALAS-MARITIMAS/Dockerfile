#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["APB.GDT.API/APB.GDT.API.csproj", "APB.GDT.API/"]
RUN dotnet restore "APB.GDT.API/APB.GDT.API.csproj"
COPY . .
WORKDIR "/src/APB.GDT.API"
RUN dotnet build "APB.GDT.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APB.GDT.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APB.GDT.API.dll"]