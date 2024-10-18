using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Blocks;

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

        builder.ComplexProperty(b => b.Code, tb =>
        {
            tb.Property(c => c.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.CODE_MAX_LENGHT)
                .HasColumnName("code");
        });
    }
}