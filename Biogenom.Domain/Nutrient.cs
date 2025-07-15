namespace Biogenom.Domain;

/// <summary>
/// Нутриент — витамин/минерал
/// </summary>
public class Nutrient
{
    public int Id { get; set; }
    /// <summary>
    /// Название нутриента: "Витамин C" и т.д.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Нынешнее значение.
    /// </summary>
    public double CurrentValue { get; set; }
    /// <summary>
    /// Нормальное значение
    /// </summary>
    public double NormValue { get; set; }
    /// <summary>
    /// Из БАДов
    /// </summary>
    public double? FromSupplements { get; set; }
    /// <summary>
    /// Из пищи
    /// </summary>
    public double? FromFood { get; set; }
    public int NutritionAssessmentId { get; set; }
    public NutritionAssessment Assessment { get; set; }
}