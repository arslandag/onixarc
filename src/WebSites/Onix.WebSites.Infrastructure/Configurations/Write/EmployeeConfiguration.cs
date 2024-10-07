using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities;

namespace Onix.WebSites.Infrastructure.Configurations.Write;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => EmployeeId.Create(value));

        builder.ComplexProperty(e => e.FullName, tb =>
        {
            tb.Property(l => l.LastName)
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .IsRequired(false)
                .HasColumnName("lastname");
            
            tb.Property(f => f.FirstName)
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .IsRequired()
                .HasColumnName("firstname");

            tb.Property(p => p.Patronymic)
                .HasMaxLength(Constants.NAME_MAX_LENGHT)
                .IsRequired(false)
                .HasColumnName("patronymic");
        });

        builder.ComplexProperty(e => e.Description, tb =>
        {
            tb.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.DESCRIPTION_MAX_LENGHT)
                .HasColumnName("description");
        });

        builder.HasOne(e => e.Photo)
            .WithOne()
            .HasForeignKey<Photo>("employee_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}