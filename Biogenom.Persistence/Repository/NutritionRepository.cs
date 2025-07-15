using Biogenom.Application;
using Biogenom.Application.Interfaces;
using Biogenom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Persistence.Repository;

public class NutritionRepository : INutritionRepository
{
    private readonly IBiogenomDbContextFactory _db;

    public NutritionRepository(IBiogenomDbContextFactory db)
    {
        _db = db;
    }
    
    public async Task<NutritionAssessment?> GetLatestAssessmentAsync()
    {
        using (var context = await _db.CreateDbContextAsync())
        {
            var nutritionAssessment  = await context.NutritionAssessments
                .Include(a => a.Nutrients)
                .Include(a => a.Supplements)
                .ThenInclude(s => s.Benefits)
                .OrderByDescending(a => a.AssessmentDate)
                .FirstOrDefaultAsync();
            return nutritionAssessment;
        }
    }
}