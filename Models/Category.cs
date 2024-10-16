namespace DigitalMenuApi.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public string ImageUrl { get; set; } = "";
    public string PageDescription {get; set;} = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}