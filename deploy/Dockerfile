FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pokemon.sln", "./"]
COPY ["apps/PokemonApi/PokemonApi.csproj", "apps/PokemonApi/"]
COPY ["src/Pokemon/Pokemon.csproj", "src/Pokemon/"]
COPY ["apps/PokemonConsole/PokemonConsole.csproj", "apps/PokemonConsole/"]
COPY ["apps/UserApi/UserApi.csproj", "apps/UserApi/"]
COPY ["src/Users/Users.csproj", "src/Users/"]

RUN dotnet restore 
COPY . .

WORKDIR "/src/apps/PokemonApi"
RUN dotnet build -c Release -o /app

WORKDIR "/src/apps/PokemonConsole"
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PokemonApi.dll"]