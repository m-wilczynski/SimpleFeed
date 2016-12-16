cd %~dp0
cd src/SimpleFeed.Data
dotnet ef --startup-project ..\SimpleFeed.Web\ database update