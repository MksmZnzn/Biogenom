namespace Biogenom.Application.Models;

public class NutrientDto
{
    /// <summary>
    /// Имя нутриента
    /// </summary>
    public string Name { get; set; }
    public double CurrentValue { get; set; }
    public double NormValue { get; set; }
    /// <summary>
    /// Из БАДов
    /// </summary>
    public double? FromSupplements { get; set; }
    /// <summary>
    /// Из пищи
    /// </summary>
    public double? FromFood { get; set; }
    
    public double DeficiencyPercentage 
        => Math.Round((NormValue - CurrentValue) / NormValue * 100, 2);
}