using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Locations;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("location");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasConversion(
                id => id.Value,
                value => LocationId.Create(value));

        builder.ComplexProperty(l => l.Name, tb =>
        {
            tb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .HasColumnName("name");
        });
        
        builder.ComplexProperty(l => l.LocationPhone, tb =>
        {
            tb.Property(p => p.Value)
                .IsRequired(false)
                .HasMaxLength(Constants.PHONE_MAX_LENGHT)
                .HasColumnName("phone");
        });
        
        builder.ComplexProperty(l => l.LocationAddress, tb =>
        {
            tb.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(Constants.ADDRESS_MAX_LENGHT)
                .HasColumnName("city");
            
            tb.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(Constants.ADDRESS_MAX_LENGHT)
                .HasColumnName("street");
            
            tb.Property(p => p.Build)
                .IsRequired()
                .HasMaxLength(Constants.ADDRESS_MAX_LENGHT)
                .HasColumnName("build");
            
            tb.Property(p => p.Index)
                .IsRequired(false)
                .HasMaxLength(Constants.INDEX_MAX_LENGHT)
                .HasColumnName("index");
        });
        
        builder.OwnsMany(s => s.Schedules, tb =>
        {
            tb.ToJson(); 
            
            tb.Property(w => w.WeekDay)
                .IsRequired()
                .HasMaxLength(Constants.WEEKDAY_MAX_LENGHT)
                .HasColumnName("weekday");
            
            tb.Property(s => s.StartTime)
                .IsRequired()
                .HasMaxLength(Constants.TIME_MAX_LENGHT)
                .HasColumnName("startTime");
            
            tb.Property(e => e.EndTime)
                .IsRequired()
                .HasMaxLength(Constants.TIME_MAX_LENGHT)
                .HasColumnName("endTime");
        });
    }
}