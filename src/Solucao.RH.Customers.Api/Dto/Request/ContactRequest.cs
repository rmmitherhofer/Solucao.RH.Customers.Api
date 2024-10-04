namespace Solucao.RH.Customers.Api.Dto.Request;

public abstract class ContactRequest
{
    public string Name { get; set; }
    public string? Telephone { get; set; }
    public string? CellPhone { get; set; }
    public string? WhatsApp { get; set; }
    public string? Email { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
}

public class AddContactRequest : ContactRequest { }

public class UpdateContactRequest : ContactRequest
{
    public Guid CustomerId { get; set; }
}