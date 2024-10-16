namespace DigitalMenuApi.DTOs;
public class GetProductDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? CategoryName { get; set; }
    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public string UnitType { get; set; } = ""; //signle unit or unit dose
    public double Price { get; set; }
    public int Discount { get; set; } = 0;
    public double FinalPrice { get; set; }

    public string Accompaniment { get; set; } = "";
    public string TimeOfPreparation { get; set; } = "";
}
