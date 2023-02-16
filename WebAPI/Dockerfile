#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR webapp
#
#EXPOSE 80
#EXPOSE 44302
#
#
##COPY PROJECT FILES
#COPY ./*.csproj ./
#RUN dotnet restore
#
##COPY EVERYHING ELSE
#COPY . .
#RUN dotnet publish -c Release -o out
#
##Build image
#FROM mrc.microsoft.com/dotnet/sdk:5.0
#WORKDIR /webapp
#COPY --from=build /webapp/out .
#ENTRYPOINT ["dotnet", "WebAPI.dll"]



FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44302

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
RUN dotnet restore "WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]