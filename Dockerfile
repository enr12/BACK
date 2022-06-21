#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IES300.API.Application/IES300.API.Application.csproj", "IES300.API.Application/"]
COPY ["IES300.API.Services/IES300.API.Services.csproj", "IES300.API.Services/"]
COPY ["IES300.API.Domain/IES300.API.Domain.csproj", "IES300.API.Domain/"]
COPY ["IES300.API.Repository/IES300.API.Repository.csproj", "IES300.API.Repository/"]
RUN dotnet restore "IES300.API.Application/IES300.API.Application.csproj"
COPY . .
WORKDIR "/src/IES300.API.Application"
RUN dotnet build "IES300.API.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IES300.API.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet IES300.API.Application.dll