

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=AlphaDB;User Id=sa;Password=CodeGuruOzzy2025!?;TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}





