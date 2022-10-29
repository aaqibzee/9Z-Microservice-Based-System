# Pull .Net sdk image 
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
# Create working directory
WORKDIR /app
# Copy .cs proj file
COPY *.csproj ./
# Restore the dependencies
RUN dotnet restore 
# Copy to working directory
COPY . ./
# publish the applicaiton
RUN dotnet publish "PlatofrmService.csproj"  -c Release -o out
# Pull .Net runtime sdk image 
FROM mcr.microsoft.com/dotnet/aspnet:6.0
# Set the  working directory
WORKDIR  /app
# Copy the built applicaiton to app/out folder 
COPY --from=build-env /app/out . 
# Set entry point for the image, to run the application 
ENTRYPOINT [ "dotnet", "PlatofrmService.dll" ]