using GenericImporter.Domain.Entities;
using Core.Infra.Data.Contexts;
using GenericImporter.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GenericImporter.Infra.Data.Contexts
{
    public class DataContext : BaseDbContext
    {
        public DbSet<Xpto> Xpto { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new XptoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
