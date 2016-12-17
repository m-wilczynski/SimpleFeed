cd %~dp0/src/SimpleFeed.Data

@echo off
set /p name="Migration name: "

dotnet ef --startup-project ..\SimpleFeed.Web\ migrations add %name%