@echo off

set DOTNET_EXE=dotnet
set FRAMEWORK_PARAM=--framework netcoreapp2.0
set CONFIGURATION_PARAM=--configuration Release

set API_CSPROJ=.\src\Contact.Manager.Api\Contact.Manager.Api.csproj

set API_DOTNET_PARAMS=publish %API_CSPROJ% %FRAMEWORK_PARAM% %CONFIGURATION_PARAM%

echo Publishing the Evolent health contact manager project... .. .
%DOTNET_EXE% %API_DOTNET_PARAMS%
