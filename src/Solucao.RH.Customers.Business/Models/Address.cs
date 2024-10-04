using Core.DomainObjects;

namespace Solucao.RH.Customers.Business.Models;

public class Address : Entity
{
    public string Street { get; private set; }
    public string? Number { get; private set; }
    public string? Complement { get; private set; }
    public string? District { get; private set; }
    public string? ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public bool IsDeleted { get; private set; }

    public Customer Customer { get; protected set; }
    public Guid CustomerId { get; private set; }

    protected Address() { }

    public Address(Guid customerId, string street, string? number, string? complement, string? district, string? zipCode, string city, string state)
    {
        CustomerId = customerId;
        Street = street;
        Number = number;
        Complement = complement;
        District = district;
        ZipCode = zipCode;
        City = city;
        State = state;
    }

    public void Update(string street, string? number, string? complement, string? district, string? zipCode, string city, string state)
    {
        Street = street;
        Number = number;
        Complement = complement;
        District = district;
        ZipCode = zipCode;
        City = city;
        State = state;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
