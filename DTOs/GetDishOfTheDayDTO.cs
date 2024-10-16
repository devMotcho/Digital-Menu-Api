namespace DigitalMenuApi.DTOs;
public partial class GetDishOfTheDayDTO
{
    // From Product
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public string ProductImage { get; set; } = "";
    public string UnitType { get; set; } = "";
    public string ProductDescription { get; set; } = "";
    public string Accompaniment { get; set; } = "";
    public string TimeOfPreparation { get; set; } = "";
    
    public double? NewPrice { get; set; }

    public DateTime ScheduledLisbonDate { get; set; }
    public string ScheduledFormatted {get; set;} = "";
    public string DayOfWeek { get; set; } = "";
}