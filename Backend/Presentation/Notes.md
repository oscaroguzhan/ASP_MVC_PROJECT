
# Notes on Project Alpha

## Data layer

The data layer is the part of the project that handles the data. It is responsible for storing and retrieving data from the database. It is also responsible for handling the data.
when we create a context in the data layer, we need to register the dbset of the entities that we want to use and make it virtual because we want to enable lazy loading which is a feature of entity framework. We also need to add it to the startup class (Program.cs). Important to remwember that datacontext class is inherited from IdentityDbContext which is a class that is provided by the asp.net core identity package.

We need even install to necessary packages such as Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools and Microsoft.EntityFrameworkCore.Design och even packages such as Microsoft.AspNetCore.Identity and Microsoft.AspNetCore.Identity.EntityFrameworkCore.


## commands to migration database
```bash
    dotnet ef migrations add MigrationName -project ~/PROJECTPATH
    dotnet ef database update -project ~/PROJECTPATH
```