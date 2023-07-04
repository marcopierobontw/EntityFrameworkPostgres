# Intro

Basic scaffolding for a dotnet 7 project executing EF migrations against Postgres.

In order to use it, you'll need to parametrize the connection string by defining db, user and password 
in a new appsettings.json file at the root level of the project.

You will need to install entity framework as a command line utility
```
dotnet tool install --global dotnet-ef
```

You can create then a new migration with:
```
dotnet ef migrations add YOUR_MIGRATION_NAME
```
You can then enter the Migrations\MIGRATION_ID_YOUR_MIGRATION_NAME.cs file and provide the SQL in the Up() and Down() 
methods. Providing the Down() methods implementation is required for the rollback functionality.

If you want to run the migrations from your laptop you can execute:
```
dotnet ef database update
```

And if you want to rollback your database to a specific migration you can execute:
```
dotnet ef database update MIGRATION_ID
```
