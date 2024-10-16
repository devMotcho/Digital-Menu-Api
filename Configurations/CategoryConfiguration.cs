using DigitalMenuApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMenuApi.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "dishes");

        builder.HasKey(c => c.CategoryId);
        
        builder.Property(c => c.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(c => c.PageDescription)
            .HasMaxLength(1000);

        builder.Property(c => c.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); // GETDATE() for sql server

        builder.Property(c => c.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); // GETDATE() for sql server
    }
}