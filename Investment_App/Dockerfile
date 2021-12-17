#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#The lines in the Dockerfile begin with the ASP.NET image from Microsoft Container Registry
#and create an intermediate image base that exposes ports 80 and 443, and sets the working directory to /app.
#WORKDIR a directory inside your container image that can be set with the WORKDIR instruction in the Dockerfile.
#WORKDIR /myapp
#COPY . .
#then the contents of your build context directory will be copied to the /myapp dir inside your docker image.
#EXPOSE:- It informs Docker that the container listens on the specified network port(s) at runtime.It does not make the ports of the container 
#accessible to the host.It indicates the ports on which a container listens for connections.
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

#It is a type of multistage build. So we can use multiple images
#We use this image to build app. We want to optimise so that only useful things should use in run the app
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
#Copy project csproj file and restore the nuget dependencies 
COPY ["Investment_App/Investment_App.csproj", "Investment_App/"]
RUN dotnet restore "Investment_App/Investment_App.csproj"
#Copy the project remaining files and build the project
COPY . .
RUN dotnet build "Investment_App/Investment_App.csproj" -c Release -o /app/build
#Copy the project files and build our release
#dotnet publish - Publishes the application and its dependencies to a folder for deployment to a hosting system.
#-c = setting configuration flag to release
#-o = set/deploy compiled project to folder out
FROM build AS publish
RUN dotnet publish "Investment_App/Investment_App.csproj" -c Release -o /app/publish

#Dockerise Angular part 
FROM node:latest as npmisntall
RUN mkdir -p /usr
COPY Investment_App/AngularOKTA/package*.json /usr
WORKDIR /usr
RUN npm install

FROM npmisntall as npmbuild
COPY Investment_App/AngularOKTA /usr
RUN npm run build --prod

# publish /app/publish . at line 36 is a 3 column code. We are copying from publish src= /usr/dist/AngularOKTA dest= .
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=npmbuild /usr/dist/AngularOKTA ./wwwroot/scripts
##Use dotnet command to run Investment_App.dll
ENTRYPOINT ["dotnet", "Investment_App.dll"]