using Microsoft.EntityFrameworkCore;
using Task.DAL.Entities;

namespace Task.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Orders> Orders { get; set; }
}