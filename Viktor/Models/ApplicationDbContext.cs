using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Viktor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Sranec> Srances { get; set; }
        public DbSet<Measure> Measures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Sranec>()
                .Property(e => e.Measure)
                .HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => JsonConvert.DeserializeObject<Measure>(x)
                );

            modelBuilder.Entity<Sranec>()
                .HasOne(x => x.MeasureLive)
                .WithMany()
                .HasForeignKey(x => x.MeasureId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
