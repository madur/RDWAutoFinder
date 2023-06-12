# ![RDW Auto Finder App](logo.png)

.NET Core codebase containing RDW Auto Finder (a REST API that lets you search on a license plate to retrieve vehicle information). 
The information about license plate is coming from the following API's: 
[Open Data RDW: Gekentekende_voertuigen | Open Data |RDW](https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2)

## How it works

This is using ASP.NET Core with:

- [AutoMapper](http://automapper.org)
- Built-in Swagger via [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [SODA](https://dev.socrata.com/) for RDW request!
- ApiKey authentication
- DDD API Achitecture 
- Production ready API - Different .NET Configuration, ExceptionMiddileWare and Logging

## Getting started

Install the .NET Core SDK 6.0 Long Term Support: [https://www.microsoft.com/net/download/core](https://www.microsoft.com/net/download/core)

Install Microsoft Visual Studio Professional 2022 [https://visualstudio.microsoft.com/downloads](https://visualstudio.microsoft.com/downloads)

## How to Run
Choose Configuration : **Dev or Prod**
Build Solution with configuration: **dotnet build --configuration=Dev**
Run local API: **dotnet run --project "AutoFinder.API.csproj" --configuration Dev --launch-profile "AutoFinder.API"**
API will be available on browser: **[https://localhost:7062/swagger/index.html](https://localhost:7062/swagger/index.html)**
