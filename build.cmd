@echo off

set DOTNET_EXE=dotnet
set FRAMEWORK_PARAM=--framework netcoreapp2.0

set API_CSPROJ=.\src\Contact.Manager.Api\Contact.Manager.Api.csproj
set API_OUTPUT_PARAM=--output "..\..\build\Contact.Manager.Api\\"
set API_DOTNET_PARAMS=build %API_CSPROJ% %API_OUTPUT_PARAM% %FRAMEWORK_PARAM%

echo Building the Evolent health contact manager project... .. .
%DOTNET_EXE% %API_DOTNET_PARAMS%
