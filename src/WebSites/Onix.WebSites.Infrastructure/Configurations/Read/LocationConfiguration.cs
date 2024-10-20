using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;
using Onix.SharedKernel;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class LocationConfiguration : IEntityTypeConfiguration<LocationDto>
{
    public void Configure(EntityTypeBuilder<LocationDto> builder)
    {
        builder.ToTable("location");

        builder.Property(l => l.Id)
            .HasColumnName("Id");

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