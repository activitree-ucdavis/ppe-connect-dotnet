FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ADD . /app
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT [ "dotnet", "HackCOVID19.dll" ]