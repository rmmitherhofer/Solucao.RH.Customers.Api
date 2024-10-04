using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Api.Dto.Request;

public abstract class CustomerRequest
{
    public string Cnpj { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }
    public string Site { get; set; }
}

public class AddCustomerRequest : CustomerRequest
{
    public IEnumerable<AddAddressRequest> Addresses { get; set; }
    public IEnumerable<AddContactRequest> Contacts { get; set; }
}

public class UpdateCustomerRequest : CustomerRequest { }