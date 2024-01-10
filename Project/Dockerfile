# Use a Windows Server Core base image with .NET Framework 4.8
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019 AS base
WORKDIR /app

# Copy the project files
COPY . .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point to start the application
ENTRYPOINT ["C:\\app\\Project.exe"]
