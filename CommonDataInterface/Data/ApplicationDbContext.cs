using CommonDataInterface.Models;
using Microsoft.EntityFrameworkCore;
namespace CommonDataInterface.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Mpi_DemographicInfo> MPI_DEMOGRAPHICINFO { get; set; }
    public DbSet<EHR_PastHistoryRecord> EHR_PASTHISTORYRECORD { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseSqlServer("Server=10.200.200.11,1433;Initial Catalog=CHDB;User ID=SA;Password=P@ssw0rd2023;TrustServerCertificate=true;MultipleActiveResultSets=true");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //All Decimals will have 18,6 Range
        // foreach (var property in builder.Model.GetEntityTypes()
        // .SelectMany(t => t.GetProperties())
        // .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        // {
        //     property.SetColumnType("decimal(18,6)");
        // }
        base.OnModelCreating(builder);
        // builder.Seed();
    }
}