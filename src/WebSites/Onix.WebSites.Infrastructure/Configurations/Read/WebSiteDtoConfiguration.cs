using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class WebSiteDtoConfiguration : IEntityTypeConfiguration<WebSiteDto>
{
    public void Configure(EntityTypeBuilder<WebSiteDto> builder)
    {
        builder.ToTable("website");

        builder.HasKey(w => w.Id);

        builder.OwnsMany(w => w.Socials, tb =>
        {
            tb.Property(s => s.Social)
                .IsRequired(false)
                .HasColumnName("social");

            tb.Property(l => l.Link)
                .IsRequired(false)
                .HasColumnName("link");
        });
        
        builder.HasMany(w => w.Blocks)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("website_id");
    }
}