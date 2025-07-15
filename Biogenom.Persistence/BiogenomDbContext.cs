using Biogenom.Application.Interfaces;
using Biogenom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Persistence;

public class BiogenomDbContext : DbContext, IBiogenomDbContext
{
    public DbSet<NutritionAssessment> NutritionAssessments { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Supplement> Supplements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Benefit> Benefits { get; set; }
    
    public BiogenomDbContext(DbContextOptions<BiogenomDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Assessments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
        
        modelBuilder.Entity<NutritionAssessment>()
            .HasMany(a => a.Nutrients)
            .WithOne(n => n.Assessment)
            .HasForeignKey(n => n.NutritionAssessmentId);

        modelBuilder.Entity<Supplement>()
            .HasMany(s => s.Benefits)
            .WithOne(b => b.Supplement)
            .HasForeignKey(b => b.SupplementId);
        
        modelBuilder.Entity<NutritionAssessment>()
            .HasMany(a => a.Supplements)
            .WithOne(s => s.Assessment)
            .HasForeignKey(s => s.NutritionAssessmentId);
    }
}