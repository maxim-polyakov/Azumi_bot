FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build

WORKDIR /source

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore --disable-parallel
# Build and publish a release
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080
ADD run.sh /
ENTRYPOINT ["/bin/sh", "/run.sh"]
CMD ["runserver","0.0.0.0:8000"]
