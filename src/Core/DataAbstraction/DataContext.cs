using Microsoft.EntityFrameworkCore;

namespace noo.api.Core.DataAbstraction;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
}