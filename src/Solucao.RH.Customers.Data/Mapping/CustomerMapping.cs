using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Data.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(c => c.Cnpj)
            .HasColumnType("varchar(14)")
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Telephone)
            .HasColumnType("varchar(15)");

        builder.Property(c => c.Cellphone)
            .HasColumnType("varchar(15)");

        builder.Property(c => c.Email)
            .HasColumnType($"varchar({Email.AddressMaxLength})");

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId);

        builder.HasMany(c => c.Contacts)
            .WithOne(ct => ct.Customer)
            .HasForeignKey(ct => ct.CustomerId);

        builder.ToTable("Customers");
    }
}
