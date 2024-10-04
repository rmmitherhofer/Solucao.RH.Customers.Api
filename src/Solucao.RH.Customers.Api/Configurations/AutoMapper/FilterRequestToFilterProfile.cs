using Api.Core.Data.Filters;
using Api.Requests;
using AutoMapper;
using Solucao.RH.Customers.Api.Dto.Request;
using Solucao.RH.Customers.Business.Filters;

namespace Solucao.RH.Customers.Api.Configurations.AutoMapper;

public class FilterRequestToFilterProfile : Profile
{
    public FilterRequestToFilterProfile()
    {
        CreateMap<FilterRequest, Filter>();

        CreateMap<CustomerFilterRequest, CustomerFilter>();
    }
}
