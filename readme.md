# Glofox Tech Task Readme

Below are the commands to run this project, I have included commands for  Windows MacOs and linux however as I do not have access to a mac for the development of this code I cannot guarantee that it will run correctly but I would be confident that there will be no issues


# Windows
open the cmd prompt (can be found by search for cmd in the start menu)
navigate to the location of the project and run the following command
````
.\dotnet-install.ps1
````
once the installation has finished run this command
````
dotnet run --project .\GlofoxTechTask\GlofoxTechTask.csproj
````
next open your browser of choice and go to https://localhost:5001/swagger

this will load the swagger page for this project.

# MacOs/Linux
open the Terminal (can be found by searching for Terminal in Launchpad)
navigate to the location of the project and run the following command
````
.\dotnet-install.sh
````
once the installation has finished run this command
````
dotnet run --project .\GlofoxTechTask\GlofoxTechTask.csproj
````
next open your browser of choice and go to https://localhost:5001/swagger

this will load the swagger page for this project.