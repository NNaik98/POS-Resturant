# Point of Sales Restaurant API

To develop locally:

1. Navigate to `/src`
1. Install dependencies - `dotnet restore`
1. If this is the initial setup:
   1. Create the schema in MySQL (initial only) - `dotnet ef update database`
   1. Create `appsettings.json` in `/src` and copy the JSON below into it
1. Start the dev server
   - `dotnet watch` - restarts the server to apply new changes on save
   - `dotnet run` - doesn't restart but still an option if `watch` doesn't work out

You'll need to create `appsettings.Development.json` if you want to test locally and `appsettings.json` if you want to create a production instance on the machine.

appsettings.json

```json
{
	"DbConnections": {
		"POSAPI": "Server=;Port=;Database=;uid=;pwd=;" // or any other MySQL connection string
	},
	"Logging": {
		"LogLevel": {
			"Default": "Information",
			"Microsoft": "Warning",
			"Microsoft.Hosting.Lifetime": "Information"
		}
	}
}
```

Built with

- [.NET 6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [EF Core 6](https://docs.microsoft.com/en-us/ef/core/)

That's it, plain and simple!
