#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SmallProject.UserService/SmallProject.UserService.csproj", "SmallProject.UserService/"]
COPY ["SmallProject.UserService.Infrastructure/SmallProject.UserService.Infrastructure.csproj", "SmallProject.UserService.Infrastructure/"]
COPY ["SmappProject.UserService.Domain/SmallProject.UserService.Domain.csproj", "SmappProject.UserService.Domain/"]
COPY ["SmallProject.UserService.Application/SmallProject.UserService.Application.csproj", "SmallProject.UserService.Application/"]
RUN dotnet restore "SmallProject.UserService/SmallProject.UserService.csproj"
COPY . .
WORKDIR "/src/SmallProject.UserService"
RUN dotnet build "SmallProject.UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmallProject.UserService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmallProject.UserService.dll"]