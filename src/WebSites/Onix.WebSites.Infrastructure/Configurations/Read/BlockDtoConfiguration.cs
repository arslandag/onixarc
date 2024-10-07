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

        builder.HasOne(b => b.BackPhoto)
            .WithOne()
            .HasForeignKey("block_id");

        builder.HasMany(b => b.Services)
            .WithOne()
            .HasForeignKey("block_id");

        builder.HasMany(b => b.Products)
            .WithOne()
            .HasForeignKey("block_id");

        builder.HasMany(b => b.Employees)
            .WithOne()
            .HasForeignKey("block_id");

        builder.HasMany(b => b.Photos)
            .WithOne()
            .HasForeignKey("block_id");
    }
}