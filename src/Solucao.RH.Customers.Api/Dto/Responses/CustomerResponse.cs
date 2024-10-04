using Api.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class CustomerResponse : Response
{
    public string Cnpj { get; set; }
    public string Name { get; set; }
    public string? Telephone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
    public IEnumerable<AddressResponse> Addresses { get; set; }
    public IEnumerable<ContactResponse>? Contacts { get; set; }

}
