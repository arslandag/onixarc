using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Core.Dtos;

namespace Onix.WebSites.Infrastructure.Configurations.Read;

public class PhotoConfiguration : IEntityTypeConfiguration<PhotoDto>
{
    public void Configure(EntityTypeBuilder<PhotoDto> builder)
    {
        builder.ToTable("photo");

        builder.HasKey(p => p.Id);
    }
}