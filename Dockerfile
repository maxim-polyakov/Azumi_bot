FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
	
ADD run.sh /
ENTRYPOINT ["/bin/sh", "/run.sh"]
