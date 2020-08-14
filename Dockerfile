FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

ADD ./src /src

RUN dotnet restore /src
RUN dotnet publish -c Release -o /bundle /src/YandexTest.Server.Api

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /bundle
COPY --from=build-env /bundle ./

CMD ["dotnet", "/bundle/YandexTest.Server.Api.dll", "run"]