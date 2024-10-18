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
    }
}