using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotnetMySqlEF.Data.Models;

public class PersonContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public PersonContext(IConfiguration configuratation)
    {
        _configuration = configuratation;
        _connectionString = _configuration.GetConnectionString("default");
        
    }
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }
}
