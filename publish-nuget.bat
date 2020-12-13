@echo off

echo Initialize solution clean

dotnet clean --configuration Release --nologo --verbosity quiet

echo Finished solution clean

echo Restore nuget packages

dotnet restore --force %~dp0MeControla.Core.sln --verbosity quiet

echo Initialize solution build

dotnet build %~dp0MeControla.Core.sln --configuration Release --nologo --verbosity quiet

echo Finished solution build

echo Publish package in nuget

dotnet nuget push "%~dp0MeControla.Core/bin/Release/MeControla.Core.1.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

pause