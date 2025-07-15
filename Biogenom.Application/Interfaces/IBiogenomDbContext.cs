using Biogenom.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Biogenom.Application.Interfaces;

public interface IBiogenomDbContext : IDisposable
{
    public DbSet<NutritionAssessment> NutritionAssessments { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Supplement> Supplements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Benefit> Benefits { get; set; }
}