FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY ./src/ESoftPlus.Api/bin/docker .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5000
ENTRYPOINT dotnet ESoftPlus.Api.dll