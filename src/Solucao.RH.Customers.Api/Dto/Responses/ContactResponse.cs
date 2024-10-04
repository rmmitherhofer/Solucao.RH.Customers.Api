using Api.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class ContactResponse : Response
{
    public string Name { get; set; }
    public string? Telephone { get; set; }
    public string? CellPhone { get; set; }
    public string? WhatsApp { get; set; }
    public string? Email { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
}