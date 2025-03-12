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
    public DbSet<UnitOfMeasure> unitOfMeasures { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var countries = LoadCountriesFromJson("Data/Seed/countries.json");
        modelBuilder.Entity<Country>().HasData(countries);

        var unitOfMeasure = LoadUnitOfMeasureFromJson("Data/Seed/unitOfMeasure.json");
        modelBuilder.Entity<UnitOfMeasure>().HasData(countries);

        base.OnModelCreating(modelBuilder);
    }

    private List<Country> LoadCountriesFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Country>>(json)?? new List<Country>();
    }
    private List<UnitOfMeasure> LoadUnitOfMeasureFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<UnitOfMeasure>>(json)?? new List<UnitOfMeasure>();
    }
}
