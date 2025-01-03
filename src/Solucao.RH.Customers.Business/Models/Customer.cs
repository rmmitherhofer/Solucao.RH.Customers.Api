using Core.DomainObjects;
using Core.ValueObjects;
using Solucao.RH.Customers.Business.Enums;

namespace Solucao.RH.Customers.Business.Models;

public class Customer : Entity, IAggregateRoot
{
    public long Code { get; private set; }
    public string Cnpj { get; private set; }
    public string Name { get; private set; }
    public string? Telephone { get; private set; }
    public string? Cellphone { get; private set; }
    public string? Email { get; private set; }
    public string? Site { get; private set; }
    public DateTime? FoundationDate { get; private set; }
    public string? StateRegistration { get; private set; }
    public string? MunicipalRegistration { get; private set; }
    public string? Segment { get; private set; }
    public string? CompanySize { get; private set; }
    public Guid? UserId { get; private set; }
    public Status Status { get; private set; }
    public string? BusinessArea { get; private set; }
    public string? Classification { get; private set; }
    public string? Type { get; private set; }
    public string? Origin { get; private set; }

    private List<Address> _addresses = [];
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    private List<Contact> _contacts = [];
    public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

    protected Customer() { }

    public Customer(string cnpj, string name, string? telephone, string? cellphone, string? email, string? site,
        DateTime? foundationDate, string? stateRegistration, string? municipalRegistration, string? segment, string? companySize,
        Guid? userId, Status status, string? businessArea, string? classification, string? type, string? origin)
    {
        Cnpj = new Cnpj(cnpj).Number;
        Name = name;
        Telephone = telephone;
        Cellphone = cellphone;
        Email = new Email(email).Address;
        Site = site;
        FoundationDate = foundationDate;
        StateRegistration = stateRegistration;
        MunicipalRegistration = municipalRegistration;
        Segment = segment;
        CompanySize = companySize;
        UserId = userId;
        Status = status;
        BusinessArea = businessArea;
        Classification = classification;
        Type = type;
        Origin = origin;
    }

    public void Update(string? telephone, string? cellphone, string? email, string? site,
        DateTime? foundationDate, string? stateRegistration, string? municipalRegistration, string? segment, string? companySize,
        Guid? userId, Status status, string? businessArea, string? classification, string? type, string? origin)
    {
        Telephone = telephone;
        Cellphone = cellphone;
        Email = new Email(email).Address;
        Site = site;
        FoundationDate = foundationDate;
        StateRegistration = stateRegistration;
        MunicipalRegistration = municipalRegistration;
        Segment = segment;
        CompanySize = companySize;
        UserId = userId;
        Status = status;
        BusinessArea = businessArea;
        Classification = classification;
        Type = type;
        Origin = origin;
    }

    public void AddAddress(string street, string? number, string? complement, string? district, string? zipCode, string city, string state, string country)
    {
        _addresses ??= [];

        _addresses.Add(new(Id, street, number, complement, district, zipCode, city, state, country));
    }

    public void AddContact(string name, string? telephone, string? cellPhone, string? whatsApp, string? email, string? department, string? position)
    {
        _contacts ??= [];

        _contacts.Add(new(Id, name, telephone, cellPhone, whatsApp, email, department, position));
    }
}
