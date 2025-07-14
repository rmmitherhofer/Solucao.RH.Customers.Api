using AutoMapper;
using Solucao.RH.Customers.Api.Dto.Request;
using Solucao.RH.Customers.Business.Filters;
using Zypher.Persistence.Abstractions.Data.Filters;
using Zypher.Requests;

namespace Solucao.RH.Customers.Api.Configurations.AutoMapper;

public class FilterRequestToFilterProfile : Profile
{
    public FilterRequestToFilterProfile()
    {
        CreateMap<FilterRequest, Filter>();

        CreateMap<CustomerFilterRequest, CustomerFilter>();
    }
}
