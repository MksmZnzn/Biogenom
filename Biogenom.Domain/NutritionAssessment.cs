namespace Biogenom.Domain;

/// <summary>
/// Оценка питания
/// </summary>
public class NutritionAssessment
{
    public int Id { get; set; }
    public DateTime AssessmentDate { get; set; }
    public string Status { get; set; } // "Дефицит", "Норма" и т.д.
    
    // Связи
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<Nutrient> Nutrients { get; set; } = new();
    public List<Supplement> Supplements { get; set; } = new();
}