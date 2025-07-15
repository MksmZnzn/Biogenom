using Biogenom.Domain;

namespace Biogenom.Application.Interfaces;

public interface INutritionRepository
{
    Task<NutritionAssessment?> GetLatestAssessmentAsync();
}