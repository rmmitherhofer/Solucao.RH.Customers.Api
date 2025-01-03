using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Data.Mapping;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.RegistrationDate)
            .IsRequired();

        builder.Property(a => a.DateChanged);

        builder.Property(a => a.Street)
            .HasColumnType("varchar(150)");

        builder.Property(a => a.Number)
            .HasColumnType("varchar(10)");

        builder.Property(a => a.Complement)
            .HasColumnType("varchar(60)");

        builder.Property(a => a.District)
            .HasColumnType("varchar(120)");

        builder.Property(a => a.ZipCode)
            .HasColumnType("varchar(10)");

        builder.Property(a => a.City)
            .HasColumnType("varchar(120)")
            .IsRequired(); 

        builder.Property(a => a.State)
            .HasColumnType("varchar(120)")
            .IsRequired();

        builder.Property(a => a.Country)
            .HasColumnType("varchar(120)")
            .IsRequired();

        builder.Property(a => a.IsDeleted)
            .IsRequired();

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Addresses);

        builder.ToTable("Addresses");
    }
}
