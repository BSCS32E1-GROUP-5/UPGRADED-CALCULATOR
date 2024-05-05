using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class SimpleCalculatorContext : DbContext
    {
        public DbSet<calc> SimpleCalculator { get; set; }

        public SimpleCalculatorContext(DbContextOptions<SimpleCalculatorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<calc>()
                .HasKey(c => c.Number); // Assuming 'Number' is the primary key property in your 'calc' entity
        }
    }
}