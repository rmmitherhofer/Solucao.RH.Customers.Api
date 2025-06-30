using Api.Core;
using Common.Core.Enums;
using Common.Notifications.Interfaces;
using Common.Notifications.Messages;
using FluentValidation.Results;
using Logs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Data;

public class CustomerContext(DbContextOptions<CustomerContext> options, INotificationHandler notification, ILogger<CustomerContext> logger) : DbContext(options), IUnitOfWork
{
    private const string RegistrationDate = nameof(RegistrationDate);
    private const string DateChanged = nameof(DateChanged);
    private readonly ILogger<CustomerContext> _logger = logger;

    private readonly INotificationHandler _notification = notification;

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e =>
                e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(150)");
        }

        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }

        modelBuilder.HasSequence<int>("SQ_Customer").StartsAt(1).IncrementsBy(1);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<(bool, OperationType)> CommitDetailed()
    {
        var operationType = ValidateChange();

        var success = await SaveChangesAsync();
        
        return (success, operationType);
    }

    public async Task<bool> Commit()
    {
        ValidateChange();

        var success = await SaveChangesAsync();

        return (success);
    }

    private async Task<bool> SaveChangesAsync()
    {
        var success = false;
        try
        {
            if (_notification.HasNotifications()) return success;

            success = await base.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            _notification.Notify(new Notification(LogLevel.Critical, ex.GetType().Name, "SQL-Server", ex.Message));

            _logger.LogCrit(ex.Message);
        }
        return success;
    }
    private OperationType ValidateChange()
    {
        OperationType operationType = OperationType.None;
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(RegistrationDate) != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(RegistrationDate).CurrentValue = DateTime.Now;
                operationType = OperationType.Added;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(RegistrationDate).IsModified = false;

                entry.Property(DateChanged).CurrentValue = DateTime.Now;

                operationType = OperationType.Modified;
            }

            if (entry.State == EntityState.Deleted)
                operationType = OperationType.Deleted;
        }
        return operationType;
    }
}
