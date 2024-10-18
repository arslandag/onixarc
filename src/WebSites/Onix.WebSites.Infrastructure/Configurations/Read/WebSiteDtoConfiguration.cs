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
        
        builder.Property(w => w.Id)
            .HasColumnName("Id");
        
        builder.Property(w => w.Url)
            .HasColumnName("url");
        
        builder.HasMany(w => w.Blocks)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(b => b.WebSiteId);
        
        builder.HasMany(w => w.Categories)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(b => b.WebSiteId);

        builder.HasMany(w => w.Favicon)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(f => f.WebSiteId);
        
        builder.HasMany(c => c.Location)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(p => p.WebSiteId);
    }
}