using AutoMapper;
using Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Anticorruption.AutoMapper;

public class EntityToHttpRequestProfile : Profile
{
    public EntityToHttpRequestProfile()
    {
        CreateMap<Customer, CustomerHttpRequest>()
            .ForPath(d => d.CustomerId, o => o.MapFrom(s => s.Id));

        CreateMap<Address, AddressHttpRequest>()
            .ForPath(d => d.AddressId, o => o.MapFrom(s => s.Id));

        CreateMap<Contact, ContactHttpRequest>()
            .ForPath(d => d.ContactId, o => o.MapFrom(s => s.Id));
    }
}
