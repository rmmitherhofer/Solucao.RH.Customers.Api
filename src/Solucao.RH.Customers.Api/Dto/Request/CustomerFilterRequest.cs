using Api.Requests;

namespace Solucao.RH.Customers.Api.Dto.Request;

public class CustomerFilterRequest : FilterRequest
{
    public string? Cnpj { get; set; }
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }

}

