using Microsoft.EntityFrameworkCore;
using Optimizasyon.Core.Domain.Entities;

namespace Optimizasyon.Infrastructure.Persistence
{
    public class OptimizasyonDbContext : DbContext
    {
        public OptimizasyonDbContext(DbContextOptions<OptimizasyonDbContext> options)
            : base(options) { }

        public DbSet<MarangozModel> MarangozModels { get; set; }
    }
}
