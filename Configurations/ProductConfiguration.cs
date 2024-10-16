using DigitalMenuApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMenuApi.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "dbo");

        builder.Property(p => p.Name)
            .HasMaxLength(26)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000);
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Accompaniment)
            .HasMaxLength(55);
        
        builder.Property(p => p.TimeOfPreparation)
            .HasMaxLength(15);
        
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); // GETDATE() for sql server

        builder.Property(p => p.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); // GETDATE() for sql server
    }
}