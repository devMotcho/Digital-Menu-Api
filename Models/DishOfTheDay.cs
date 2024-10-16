namespace DigitalMenuApi.Models;

public partial class DishOfTheDay
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateTime ScheduledOn { get; set; }
    public double? NewPrice { get; set; }
    public int ScheduledWeek { get; set; }
    public virtual Product Product { get; set; } = null!;


}