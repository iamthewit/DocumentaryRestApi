# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application files and publish the app
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expose the port the application runs on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "DocumentaryRestApi.dll"]