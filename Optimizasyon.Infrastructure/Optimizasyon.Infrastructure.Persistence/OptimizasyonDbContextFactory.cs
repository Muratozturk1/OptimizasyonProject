using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Optimizasyon.Infrastructure.Persistence;

public class OptimizasyonDbContextFactory : IDesignTimeDbContextFactory<OptimizasyonDbContext>
{
    public OptimizasyonDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OptimizasyonDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-C47H53I\\SQLEXPRESS;Database=Optimizasyon;Trusted_Connection=True;TrustServerCertificate=True");

        return new OptimizasyonDbContext(optionsBuilder.Options);
    }
}
