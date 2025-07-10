using Common.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Data.Mapping;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegistrationDate)
            .IsRequired();

        builder.Property(c => c.DateChanged);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(c => c.Telephone)
            .HasColumnType("varchar(15)");

        builder.Property(c => c.CellPhone)
            .HasColumnType("varchar(15)");

        builder.Property(c => c.WhatsApp)
            .HasColumnType("varchar(15)");

        builder.Property(c => c.Email)
            .HasColumnType($"varchar({Email.AddressMaxLength})");

        builder.Property(c => c.Department)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.Position)
            .HasColumnType("varchar(150)");

        builder.Property(c => c.IsDeleted)
            .IsRequired();

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Contacts);

        builder.ToTable("Contacts");
    }
}