using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities;

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

        builder.OwnsOne(s => s.Price, tb =>
        {
            tb.Property(p => p.Value)
                .IsRequired(false)
                .HasColumnName("price");
        });

        builder.OwnsOne(s => s.Duration, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired(false)
                .HasColumnName("duration");
        });
        
        builder.OwnsOne(s => s.Link, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.LINK_MAX_LENGHT)
                .HasColumnName("link");
        });

        builder.HasMany(s => s.ServicePhotos)
            .WithOne()
            .HasForeignKey("service_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}