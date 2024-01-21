using BeSql.Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeSql.Client.Data;

public class OfflineDbContext(DbContextOptions<OfflineDbContext> options)
    : DbContext(options)
{
    static OfflineDbContext()
    {
        if (OperatingSystem.IsBrowser())
        {
            // To make optimized db context work in blazor wasm: https://github.com/dotnet/efcore/issues/31751
            // https://learn.microsoft.com/en-us/ef/core/performance/advanced-performance-topics?tabs=with-di%2Cexpression-api-with-constant#compiled-models
            AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue31751", true);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use configuration from files
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OfflineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            // Enable below if using compiled models
            //.UseModel(OfflineDbContextModel.Instance) // use generated compiled model in order to make db context optimized
            .UseSqlite("Data Source=Offline-ClientDb.db");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // SQLite does not support expressions of type 'DateTimeOffset' in ORDER BY clauses. Convert the values to a supported type:
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetToBinaryConverter>();
        configurationBuilder.Properties<DateTimeOffset?>().HaveConversion<DateTimeOffsetToBinaryConverter>();
    }

    public DbSet<CalculationResult> CalculationResults { get; set; }
}