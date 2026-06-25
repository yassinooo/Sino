# FishingApp

Solution scaffold (WPF MVVM + 3-tier):
- FishingApp.Models (POCOs)
- FishingApp.Data (EF Core DbContext, GenericRepository)
- FishingApp.Business (services)
- FishingApp.UI (WPF .NET 7, MVVM minimal example)

How to use:
1. Ensure .NET 7 SDK is installed.
2. Edit FishingApp.UI\appsettings.json to set your SQL Server connection string (or modify it after cloning).
3. From solution folder run dotnet restore and dotnet build.

To apply EF migrations (optional):
- Install dotnet-ef tool if needed:
    dotnet tool install --global dotnet-ef
- Add migration from the Data project:
    cd FishingApp.Data
    dotnet ef migrations add Initial --project . --startup-project ..\FishingApp.UI
    dotnet ef database update --project . --startup-project ..\FishingApp.UI

Or run the provided SQL script CreateDatabase.sql on your SQL Server.
