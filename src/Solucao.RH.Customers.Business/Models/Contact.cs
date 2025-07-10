using Common.Core.DomainObjects;
using Common.Core.ValueObjects;

namespace Solucao.RH.Customers.Business.Models;

public class Contact : Entity
{
    public string Name { get; private set; }
    public string? Telephone { get; private set; }
    public string? CellPhone { get; private set; }
    public string? WhatsApp { get; private set; }
    public string? Email { get; private set; }
    public string? Department { get; private set; }
    public string? Position { get; private set; }
    public bool IsDeleted { get; private set; }

    public Customer Customer { get; protected set; }
    public Guid CustomerId { get; private set; }

    protected Contact() { }

    public Contact(Guid customerId, string name, string? telephone, string? cellPhone, string? whatsApp, string? email, string? department, string? position)
    {
        Name = name;
        Telephone = telephone;
        CellPhone = cellPhone;
        WhatsApp = whatsApp;
        Email = new Email(email).Address;
        Department = department;
        Position = position;
        CustomerId = customerId;
    }

    public void Update(string? telephone, string? cellPhone, string? whatsApp, string? email, string? department, string? position)
    {
        Telephone = telephone;
        CellPhone = cellPhone;
        WhatsApp = whatsApp;
        Email = new Email(email).Address;
        Department = department;
        Position = position;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}