using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("photo");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PhotoId.Create(value));

        builder.ComplexProperty(p => p.Path, tb =>
        {
            tb.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(Constants.PATH_MAX_LENGHT)
                .HasColumnName("path");
        });
    }
}