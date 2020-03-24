# fractal-groups

Repository contains two projects and a database backup

- "FractalGroupsApi" folder contains the Vistual Studio solutions for aspnet core webApi
- "fractal-groups-website" folder contains the angular website
- "dbbackup" is a batabase back up

API:

pre-requisites:
- asp.net core 3.1 SDK
- visual studio
- Sql server and management studio

How to run api:
- Restore database back up using "dbbackup"
- Load the FractalGroupsApi.sln which can be found in FractalGroupsApi folder in Visual studio
- Change the connection string in appsettings.json (It has machine name in it just change it to current machine host name)
- F5 to run in Debug 

Notes: 
- API has swagger implemented so you can start using the end points straight away.
- You can run the project using dot net cli aswell if you prefer


WEBSITE:

pre-reqsuisites:
- enusre latest version of node and npm is installed on the machine

How to serve website:
- navigate to fractal-groups-website folder
- run npm install to restore nuget package
- run ng serve command

Notes: 
- by default the API is running on port 44319 and the environment.ts file is pointed to https://localhost:44319/,
if the api part has been changed, then this will need to match the new port.







