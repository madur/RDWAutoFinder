# ![RDW Auto Finder App](logo.png)

.NET Core codebase containing RDW Auto Finder (a REST API that lets you search on a license plate to retrieve vehicle information). The information abput licenseplate is coming from the following one API’s:
Known Vehicles from the RDW: [Open Data RDW: Gekentekende_voertuigen | Open Data |RDW](https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2)

## How it works

This is using ASP.NET Core with:

- [AutoMapper](http://automapper.org)
- Built-in Swagger via [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [SODA](https://dev.socrata.com/) for RDW request!
- ApiKey authentication
- `.editorconfig` to enforce some usage patterns

