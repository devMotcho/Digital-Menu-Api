namespace DigitalMenuApi.Models;

public class Product
{

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public string ImageUrl { get; set; } = "";
    public string UnitType { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsChefRecommendation { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public double Price { get; set; }
    public int Discount { get; set; } = 0;
    public double FinalPrice { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string  Accompaniment {get; set;} = "";
    public string TimeOfPreparation { get; set; } = "";

    //Navigation Property
    public virtual Category Category { get; set; } = null!;

    public ICollection<DishOfTheDay> DishesOfTheDay { get; set; } = [];

}