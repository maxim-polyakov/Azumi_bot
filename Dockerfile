
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src

RUN dotnet build DockerServiceDemo.csproj -c Release -o /appsnap start docker

ADD run.sh /
ENTRYPOINT ["/bin/sh", "/run.sh"]