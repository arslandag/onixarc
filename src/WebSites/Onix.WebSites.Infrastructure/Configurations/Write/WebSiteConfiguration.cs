using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.WebSites;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class WebSiteConfiguration : IEntityTypeConfiguration<WebSite>
{
    public void Configure(EntityTypeBuilder<WebSite> builder)
    {
        builder.ToTable("website");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasConversion(
                id => id.Value,
                value => WebSiteId.Create(value));

        builder.ComplexProperty(w => w.Name, tb =>
        {
            tb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .HasColumnName("name");
        });
        
        builder.ComplexProperty(w => w.Url, tb =>
        {
            tb.Property(u => u.Value)
                .IsRequired()
                .HasMaxLength(Constants.URL_MAX_LENGHT)
                .HasColumnName("url");
        });

        builder.Property(w => w.ShowStatus)
            .IsRequired()
            .HasColumnName("show_status");

        builder.OwnsOne(w => w.Appearance, tb =>
        {
            tb.Property(c => c.ColorScheme)
                .IsRequired()
                .HasMaxLength(Constants.SHARE_MAX_LENGTH)
                .HasColumnName("color_scheme");

            tb.Property(b => b.ButtonStyle)
                .IsRequired()
                .HasMaxLength(Constants.SHARE_MAX_LENGTH)
                .HasColumnName("button_style");

            tb.Property(f => f.Font)
                .IsRequired()
                .HasMaxLength(Constants.SHARE_MAX_LENGTH)
                .HasColumnName("font");
        });

        builder.ComplexProperty(w => w.Phone, tb =>
        {
            tb.Property(p => p.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.PHONE_MAX_LENGHT)
                .HasColumnName("phone");
        });
        
        builder.ComplexProperty(w => w.Email, tb =>
        {
            tb.Property(e => e.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.EMAIL_MAX_LENGHT)
                .HasColumnName("email");
        });

        builder.OwnsMany(w => w.SocialMedias, tb =>
        {
            tb.ToJson();
            
            tb.Property(s => s.Social)
                .IsRequired(false)
                .HasMaxLength(Constants.SOCIAL_MAX_LENGHT)
                .HasColumnName("social");

            tb.Property(s => s.Link)
                .IsRequired(false)
                .HasMaxLength(Constants.LINK_MAX_LENGHT)
                .HasColumnName("link");
        });

        builder.OwnsMany(w => w.FAQs, tb =>
        {
            tb.ToJson();
            
            tb.Property(f => f.Answer)
                .IsRequired(false)
                .HasMaxLength(Constants.ANSWER_MAX_LENGHT)
                .HasColumnName("answer");

            tb.Property(f => f.Question)
                .IsRequired(false)
                .HasMaxLength(Constants.QUESTION_MAX_LENGHT)
                .HasColumnName("question");
        });

        builder.HasMany(w => w.Categories)
            .WithOne()
            .HasForeignKey("website_id")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Locations)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("website_id")
            .OnDelete(DeleteBehavior.Cascade);
    
        builder.HasMany(f => f.Favicon)
            .WithOne()
            .HasForeignKey("website_id")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(w => w.Blocks)
            .WithOne()
            .HasForeignKey("website_id")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}