using Microsoft.EntityFrameworkCore;
using ReferenceService.Entity;
using System.Text.Json;

namespace ReferenceService.Data;

public class ReferenceServiceDbContext : DbContext
{
    public ReferenceServiceDbContext(DbContextOptions<ReferenceServiceDbContext> options)
        : base(options)
    {
    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var countries = LoadCountriesFromJson("Data/countries.json");
        modelBuilder.Entity<Country>().HasData(countries);

        base.OnModelCreating(modelBuilder);
    }

    private List<Country> LoadCountriesFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Country>>(json);
    }
}
