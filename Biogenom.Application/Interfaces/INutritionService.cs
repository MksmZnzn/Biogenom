using Biogenom.Application.Models;

namespace Biogenom.Application.Interfaces;

public interface INutritionService
{
    Task<NutritionReportDto> GetNutritionReportAsync();
}