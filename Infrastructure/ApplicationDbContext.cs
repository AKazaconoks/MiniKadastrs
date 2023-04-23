using Microsoft.EntityFrameworkCore;
using MvcApiApplication.Models;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<PropertyTransaction> PropertyTransactions { get; set; }
}