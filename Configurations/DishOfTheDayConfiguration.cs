using DigitalMenuApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMenuApi.Configurations;

public class DishOfTheDayConfiguration : IEntityTypeConfiguration<DishOfTheDay>
{
    public void Configure(EntityTypeBuilder<DishOfTheDay> builder)
    {
        builder.ToTable("DishesOfTheDay", "dishes");

        builder.Property(d => d.ProductId)
            .IsRequired();
        
        builder.Property(d => d.ScheduledOn)
            .IsRequired();
        
        builder.HasOne(c => c.Product)
            .WithMany(p => p.DishesOfTheDay)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}