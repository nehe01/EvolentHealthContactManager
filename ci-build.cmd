@echo off

REM ci-build BUILD_NUMBER

set BUILD_NUMBER=%1%

set MAJOR_VERSION=1
set MINOR_VERSION=0
set REVISION=0
set VERSION_INFO="%MAJOR_VERSION%.%MINOR_VERSION%.%BUILD_NUMBER%.%REVISION%"
set BUILD=.\build\

::---------------------------------------------------
set API_PUBLISH_PATH=.\src\Contact.Manager.Api\bin\Release\netcoreapp2.0\publish\
set API_PACKAGE_ID=ampp-gladius-engine-api
::---------------------------------------------------

set PACKAGE_NAME=%ARTIFACT%%API_PACKAGE_ID%.%VERSION_INFO%.zip

echo ------------------------------------------------------------------------
echo build started
echo ------------------------------------------------------------------------

if exist %BUILD% (
	echo deleting old builds if any
	rd /s /q  %BUILD%
	echo done
)

call .\restore-dependencies.cmd
echo error %ERRORLEVEL%
if %errorlevel% neq 0 goto build_fail

echo ------------------------------------------------------------------------
echo

call .\build.cmd
echo error %ERRORLEVEL%
if %errorlevel% neq 0 goto build_fail

echo ------------------------------------------------------------------------
echo

call .\publish.cmd
echo error %ERRORLEVEL%
if %errorlevel% neq 0 goto build_fail

echo ------------------------------------------------------------------------
echo



exit /b

:build_fail

echo ------------------------------------------------------------------------
echo ************************** [  BUILD FAILURE  ] *************************
echo ------------------------------------------------------------------------

exit /b %errorlevel%