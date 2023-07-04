# Set build-time variables
ARG DB_NAME
ARG DB_USER
ARG DB_PSW

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /source

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the source code
COPY . .
WORKDIR /source

# Build the application
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS runtime

# Set environment variables from arguments
ENV DB_NAME=$DB_NAME
ENV DB_USER=$DB_USER
ENV DB_PSW=$DB_PSW

# Copy only the published app and its dependencies from the build stage
WORKDIR /app
COPY --from=build /app .

# Run the application
ENTRYPOINT ["dotnet", "EFConsoleApp.dll"]
