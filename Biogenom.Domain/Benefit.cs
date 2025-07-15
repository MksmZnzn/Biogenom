namespace Biogenom.Domain;

public class Benefit
{
    public int Id { get; set; }
    /// <summary>
    /// Текст преимущества
    /// </summary>
    public string Text { get; set; } // Текст преимущества
    /// <summary>
    /// Опциональная привязка к БАДу
    /// </summary>
    public int? SupplementId { get; set; }
    public Supplement Supplement { get; set; }
}