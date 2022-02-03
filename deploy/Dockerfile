# Console
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS baseconsole
WORKDIR /app

# Api
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS baseapp
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build and restore Console y Api
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./../apps/PokemonConsole/PokemonConsole.csproj", "apps/PokemonConsole/"]
COPY ["./../apps/PokemonApi/PokemonApi.csproj", "apps/PokemonApi/"]
COPY ["./../src/Pokemon/Pokemon.csproj", "src/Pokemon/"]
RUN dotnet restore "./../apps/PokemonConsole/PokemonConsole.csproj"
RUN dotnet restore "./../apps/PokemonApi/PokemonApi.csproj"
COPY . .

# Compile Console
WORKDIR "/src/apps/PokemonConsole"
RUN dotnet build "PokemonConsole.csproj" -c Release -o /app/build

# Publish Console
FROM build AS publish
RUN dotnet publish "PokemonConsole.csproj" -c Release -o /app/publish

# Run Console
FROM baseconsole AS finalconsole
WORKDIR /app
COPY --from=publish /app/publish .
RUN ["dotnet", "PokemonConsole.dll"]

# Compile Api
WORKDIR "/src/apps/PokemonApi"
RUN dotnet build "PokemonApi.csproj" -c Release -o /app/build

# Publish Api
FROM build AS publish
RUN dotnet publish "PokemonApi.csproj" -c Release -o /app/publish

# Run Api
FROM baseapp AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokemonApi.dll"]