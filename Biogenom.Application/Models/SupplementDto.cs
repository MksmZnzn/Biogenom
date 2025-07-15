namespace Biogenom.Application.Models;

public class SupplementDto
{
    public string Name { get; set; } // "Протектор BioSetting", "ED Smart"
    public string Description { get; set; }
    public int AlternativesCount { get; set; }
    
    // Дополнительное поле для UI
    public string DisplayName => $"{Name} ({AlternativesCount} альтернатив)";
}