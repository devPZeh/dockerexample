FROM microsoft/dotnet:2.1-aspnetcore-runtime

ENV ASPNETCORE_URLS=http://0.0.0.0:80

ADD src/AcademyDocker.Api/bin/build/ /app
WORKDIR /app
EXPOSE 80

ENTRYPOINT ["dotnet", "AcademyDocker.Api.dll"]
