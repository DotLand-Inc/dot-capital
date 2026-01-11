# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy solution and project files
COPY ["dotnet.sln", "./"]
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Web/Web.csproj", "src/Web/"]
COPY ["tests/Application.UnitTests/Application.UnitTests.csproj", "tests/Application.UnitTests/"]
COPY ["tests/Domain.UnitTests/Domain.UnitTests.csproj", "tests/Domain.UnitTests/"]
COPY ["tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj", "tests/Infrastructure.IntegrationTests/"]
COPY ["tests/Application.FunctionalTests/Application.FunctionalTests.csproj", "tests/Application.FunctionalTests/"]

# Restore dependencies (without global.json to avoid version conflicts)
RUN dotnet restore "dotnet.sln"

# Now copy global.json and remaining source
COPY ["global.json", "./"]

# Copy source code
COPY . .

# Build and publish
WORKDIR "/src/src/Web"
RUN dotnet build "Web.csproj" -c Release -o /app/build
RUN dotnet publish "Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Entry point
ENTRYPOINT ["dotnet", "Dotland.DotCapital.WebApi.Web.dll"]
