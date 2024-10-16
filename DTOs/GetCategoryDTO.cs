namespace DigitalMenuApi.DTOs;
public class GetCategoryDTO
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public string ImageUrl { get; set; } = "";
    public string PageDescription { get; set; } = "";
}
