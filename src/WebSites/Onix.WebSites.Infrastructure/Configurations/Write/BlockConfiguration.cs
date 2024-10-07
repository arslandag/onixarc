using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Blocks;
using Onix.WebSites.Domain.Entities;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.ToTable("block");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BlockId.Create(value));

        builder.ComplexProperty(b => b.Title, tb =>
        {
            tb.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(Constants.TITLE_MAX_LENGHT)
                .HasColumnName("title");
        });
        
        builder.ComplexProperty(b => b.Description, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.DESCRIPTION_MAX_LENGHT)
                .HasColumnName("description");
        });

        builder.HasOne(b => b.BackgroundPhoto)
            .WithOne()
            .HasForeignKey<Photo>("block_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(b => b.Products)
            .WithOne()
            .HasForeignKey("block_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(b => b.Services)
            .WithOne()
            .HasForeignKey("block_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(b => b.Employees)
            .WithOne()
            .HasForeignKey("block_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.Photos)
            .WithOne()
            .HasForeignKey("block_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.Locations)
            .WithOne()
            .HasForeignKey("block_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}