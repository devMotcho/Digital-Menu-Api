namespace DigitalMenuApi.DTOs;
public class GetChefRecommendationDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string CategoryName { get; set; }
    public string Description { get; set; } = "";
    public double Price { get; set; }
    public string ImageUrl { get; set; } = "";
    public double Discount { get; set; } = 0;
    public string UnitType { get; set; } = ""; //signle unit or unit dose
    public double FinalPrice { get; set; }
    public string  Accompaniment {get; set;} = "";
    public string TimeOfPreparation { get; set; } = "";
    
}
