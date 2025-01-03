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

        builder.Property(c => c.Code)
            .HasDefaultValueSql("NEXT VALUE FOR SQ_Customer");

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

        builder.Property(c => c.FoundationDate);

        builder.Property(c => c.StateRegistration)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Site)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.MunicipalRegistration)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Segment)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.CompanySize)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.UserId);

        builder.Property(c => c.Status)
            .IsRequired();

        builder.Property(c => c.BusinessArea)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Classification)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Type)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Origin)
            .HasColumnType("varchar(150)");

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId);

        builder.HasMany(c => c.Contacts)
            .WithOne(ct => ct.Customer)
            .HasForeignKey(ct => ct.CustomerId);

        builder.ToTable("Customers");
    }
}
