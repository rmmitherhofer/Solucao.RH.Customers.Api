namespace Solucao.RH.Customers.Api.Dto.Request;

public abstract class AddressRequest
{
    public string Street { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string? District { get; set; }
    public string? ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}


public class AddAddressRequest : AddressRequest { }


public class UpdateAddressRequest : AddressRequest
{
    public Guid CustomerId { get; set; }
}
