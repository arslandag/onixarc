using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceDto>
{
    public void Configure(EntityTypeBuilder<ServiceDto> builder)
    {
        builder.ToTable("service");

        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasColumnName("Id");

        builder.HasMany(s => s.Photos)
            .WithOne()
            .HasForeignKey(p => p.ServiceId)
            .IsRequired(false);
    }
}