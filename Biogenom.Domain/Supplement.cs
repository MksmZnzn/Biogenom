namespace Biogenom.Domain;

/// <summary>
/// БАД
/// </summary>
public class Supplement
{
    public int Id { get; set; }
    public string Name { get; set; } // "Протектор BioSetting", "ED Smart"
    public string Description { get; set; }
    public int AlternativesCount { get; set; } // 10 альтернатив
    
    public int NutritionAssessmentId { get; set; }
    public List<Benefit> Benefits { get; set; } = new();
    public NutritionAssessment Assessment { get; set; }
}