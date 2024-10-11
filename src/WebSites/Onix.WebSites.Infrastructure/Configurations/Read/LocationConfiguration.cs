using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class LocationConfiguration : IEntityTypeConfiguration<LocationDto>
{
    public void Configure(EntityTypeBuilder<LocationDto> builder)
    {
        builder.ToTable("location");

        builder.Property(l => l.Id)
            .HasColumnName("Id");
        
        builder.HasKey(l => l.Id);
    }
}