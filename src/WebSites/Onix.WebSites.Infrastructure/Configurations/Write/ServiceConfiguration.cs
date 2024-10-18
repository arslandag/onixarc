using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Categories.Entities;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("service");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => ServiceId.Create(value));

        builder.ComplexProperty(s => s.Name, tb =>
        {
            tb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .HasColumnName("name");
        });

        builder.ComplexProperty(s => s.Description, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.DESCRIPTION_MAX_LENGHT)
                .HasColumnName("description");
        });

        builder.Property(s => s.Duration)
            .IsRequired(false)
            .HasColumnName("duration");

        builder.ComplexProperty(s => s.Price, tb =>
        {
            tb.Property(p => p.Value)
                .IsRequired(false)
                .HasColumnName("price");
        });
        
        builder.ComplexProperty(s => s.Link, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.LINK_MAX_LENGHT)
                .HasColumnName("link");
        });

        builder.HasMany(s => s.ServicePhotos)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("service_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}