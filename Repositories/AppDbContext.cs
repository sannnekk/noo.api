using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class AppDbContext : DbContext
{    
    public AppDbContext(DbContextOptions options) : base(options) { }
}
