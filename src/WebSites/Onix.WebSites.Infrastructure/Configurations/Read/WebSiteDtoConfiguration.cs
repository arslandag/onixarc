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

        builder.OwnsMany(w => w.SocialMedias, tb =>
        {
            tb.ToJson();

            tb.Property(s => s.Social)
                .IsRequired(false)
                .HasColumnName("social");

            tb.Property(s => s.Link)
                .IsRequired(false)
                .HasColumnName("link");
        });

        builder.OwnsMany(w => w.FAQs, tb =>
        {
            tb.ToJson();

            tb.Property(f => f.Question)
                .IsRequired(false)
                .HasColumnName("question");

            tb.Property(f => f.Answer)
                .IsRequired()
                .HasColumnName("answer");
        });
        
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