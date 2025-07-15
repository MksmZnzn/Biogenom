namespace Biogenom.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<NutritionAssessment> Assessments { get; set; } = new();
}