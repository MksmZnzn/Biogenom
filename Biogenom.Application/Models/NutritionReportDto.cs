using Biogenom.Domain;

namespace Biogenom.Application.Models;

public class NutritionReportDto
{
    public string Status { get; set; }
    public List<NutrientDto> Nutrients { get; set; }
    public List<SupplementDto> Supplements { get; set; }
    public List<string> Benefits { get; set; }
}