namespace Biogenom.Application.Models;

public class NutritionAssessmentDto
{
    public int Id { get; set; }
    public DateTime AssessmentDate { get; set; }
    public string Status { get; set; } // "Дефицит", "Норма" и т.д.
    public List<NutrientDto> Nutrients { get; set; } = new();
    public List<SupplementDto> Supplements { get; set; } = new();
    
    public bool HasDeficiency => Status == "Дефицит";
}