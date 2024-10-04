using Api.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class AddressResponse : Response
{
    public string Street { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string? District { get; set; }
    public string? ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}
