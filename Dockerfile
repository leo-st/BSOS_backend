# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
EXPOSE 5005
EXPOSE 5000
EXPOSE 80
EXPOSE 443

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BSOSApi/*.csproj ./BSOSApi/
RUN dotnet restore

# copy everything else and build app
COPY BSOSApi/. ./BSOSApi/
WORKDIR /source
RUN dotnet build -c release  # Build the solution

# Publish the solution without using output directory
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "BSOSApi.dll"]