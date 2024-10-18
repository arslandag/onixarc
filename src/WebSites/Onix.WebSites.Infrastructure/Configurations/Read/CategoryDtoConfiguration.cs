using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class CategoryDtoConfiguration : IEntityTypeConfiguration<CategoryDto>
{
    public void Configure(EntityTypeBuilder<CategoryDto> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("Id");

        builder.HasOne<CategoryDto>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(s => s.ParentId);

        builder.HasMany(c => c.Products)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(p => p.CategoryId);
        
        builder.HasMany(c => c.Services)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(p => p.CategoryId);
    }
}