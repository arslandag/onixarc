using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class BlockDtoConfiguration : IEntityTypeConfiguration<BlockDto>
{
    public void Configure(EntityTypeBuilder<BlockDto> builder)
    {
        builder.ToTable("block");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("Id");
        
        builder.HasOne(b => b.BackPhoto)
            .WithOne()
            .HasForeignKey<PhotoDto>(p => p.BlockId)
            .IsRequired(false);

        builder.HasMany(b => b.Products)
            .WithOne()
            .HasForeignKey(p => p.BlockId)
            .IsRequired(false);

        builder.HasMany(b => b.Services)
            .WithOne()
            .HasForeignKey(s => s.BlockId)
            .IsRequired(false);

        builder.HasMany(b => b.Employees)
            .WithOne()
            .HasForeignKey(e => e.BlockId)
            .IsRequired(false);

        builder.HasMany(b => b.Photos)
            .WithOne()
            .HasForeignKey(p => p.BlockId)
            .IsRequired(false);

        builder.HasMany(b => b.Location)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(l => l.BlockId);
    }
}