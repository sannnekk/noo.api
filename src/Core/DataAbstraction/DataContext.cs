using AutoDependencyRegistration.Attributes;
using Microsoft.EntityFrameworkCore;

namespace noo.api.Core.DataAbstraction;

[RegisterClassAsScoped]
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
}