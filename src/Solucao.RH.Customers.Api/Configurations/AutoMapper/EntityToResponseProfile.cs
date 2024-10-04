using AutoMapper;
using Solucao.RH.Customers.Api.Dto.Responses;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Api.Configurations.AutoMapper;

public class EntityToResponseProfile : Profile
{
    public EntityToResponseProfile()
    {
        CreateMap<Customer, CustomerResponse>();

        CreateMap<Address, AddressResponse>();

        CreateMap<Contact, ContactResponse>();
    }
}
