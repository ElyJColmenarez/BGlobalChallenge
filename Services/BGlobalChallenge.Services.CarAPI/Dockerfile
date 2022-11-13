FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CarsAPI/CarsAPI.csproj", "CarsAPI/"]
RUN dotnet restore "Services/CarsAPI/CarsAPI.csproj"
COPY . .
WORKDIR "/src/CarsAPI"
RUN dotnet build "CarsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsAPI.dll"]
