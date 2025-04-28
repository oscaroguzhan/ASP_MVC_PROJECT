
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<UserEntity>(options)
{
    // register the entities
    public virtual DbSet<ProjectEntity> Projects { get; set; } = null!;
    public virtual DbSet<ClientEntity> Clients { get; set; } = null!;
    public virtual DbSet<StatusEntity> Statuses { get; set; } = null!;
    
}
