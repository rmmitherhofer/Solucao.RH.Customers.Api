using Core.DomainObjects;
using Core.ValueObjects;

namespace Solucao.RH.Customers.Business.Models;

public class Customer : Entity, IAggregateRoot
{
    public string Cnpj { get; private set; }
    public string Name { get; private set; }
    public string? Telephone { get; private set; }
    public string? Cellphone { get; private set; }
    public string? Email { get; private set; }
    public string? Site { get; private set; }

    private List<Address> _addresses;
    public IReadOnlyCollection<Address> Addresses => _addresses?.AsReadOnly();

    private List<Contact> _contacts;
    public IReadOnlyCollection<Contact> Contacts => _contacts?.AsReadOnly();

    protected Customer() { }
    public Customer(string cnpj, string name, string? telephone, string? email, string? cellphone, string? site)
    {
        Cnpj = new Cnpj(cnpj).Number;
        Name = name;
        Telephone = telephone;
        Cellphone = cellphone;
        Email = new Email(email).Address;
        Site = site;
    }

    public void Update(string nome, string? telephone, string? email, string? cellphone, string? site)
    {
        Name = nome;
        Telephone = telephone;
        Email = new Email(email).Address;
        Cellphone = cellphone;
        Site = site;
    }

    public void AddAddress(string street, string? number, string? complement, string? district, string? zipCode, string city, string state)
    {
        _addresses ??= [];

        _addresses.Add(new(Id, street, number, complement, district, zipCode, city, state));
    }

    public void AddContact(string name, string? telephone, string? cellPhone, string? whatsApp, string? email, string? department, string? position)
    {
        _contacts ??= [];

        _contacts.Add(new(Id, name, telephone, cellPhone, whatsApp, email, department, position));
    }
}
