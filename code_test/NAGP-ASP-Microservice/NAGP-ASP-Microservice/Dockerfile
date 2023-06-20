#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NAGP-ASP-Microservice.csproj", "NAGP-ASP-Microservice/"]
RUN dotnet restore "NAGP-ASP-Microservice/NAGP-ASP-Microservice.csproj"
WORKDIR "/src/NAGP-ASP-Microservice"
COPY . .
RUN find -type d -name bin -prune -exec rm -rf {} \; && find -type d -name obj -prune -exec rm -rf {} \;
RUN dotnet build "NAGP-ASP-Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NAGP-ASP-Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NAGP-ASP-Microservice.dll"]