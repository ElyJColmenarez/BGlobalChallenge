using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.DbContexts;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Car> Cars { get; set; }
}