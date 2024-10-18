using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Categories;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                value => CategoryId.Create(value));

        builder.ComplexProperty(c => c.Name, tb =>
        {
            tb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .HasColumnName("name");
        });

        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategory)
            .IsRequired(false)
            .HasForeignKey("parentCategory_id");

        builder.HasMany(c => c.Products)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("category_id");

        builder.HasMany(c => c.Services)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("category_id");
    }
}