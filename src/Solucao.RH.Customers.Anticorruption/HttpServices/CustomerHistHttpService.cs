using AutoMapper;
using Common.Core.Enums;
using Common.Http;
using Common.Notifications.Interfaces;
using Microsoft.AspNetCore.Http;
using Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;
using Solucao.RH.Customers.Business.Interfaces.HttpServices;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Anticorruption.HttpServices;

public class CustomerHistHttpService : HttpService, ICustomerHistHttpService
{
    private readonly IMapper _mapper;

    public CustomerHistHttpService(HttpClient httpClient, 
        IHttpContextAccessor httpContextAccessor, 
        INotificationHandler notification, 
        IMapper mapper) : base(httpClient, httpContextAccessor, notification)
    {
        _mapper = mapper;
    }

    public async Task PostAsync(Customer entity, OperationType operationType)
    {
        var request = _mapper.Map<CustomerHttpRequest>(entity);
        request.OperationType = operationType;

        var url = "api/v1/hist-customer";

        var content = SerializeContent(request);

        var response = await PostAsync(url, content);

        ValidateResponse(response);
    }

    public async Task PostAsync(Contact entity, OperationType operationType)
    {
        var request = _mapper.Map<ContactHttpRequest>(entity);
        request.OperationType = operationType;

        var url = "api/v1/hist-contact";

        var content = SerializeContent(request);

        var response = await PostAsync(url, content);


        ValidateResponse(response);
    }

    public async Task PostAsync(Address entity, OperationType operationType)
    {
        var request = _mapper.Map<AddressHttpRequest>(entity);
        request.OperationType = operationType;

        var url = "api/v1/hist-address";

        var content = SerializeContent(request);

        var response = await PostAsync(url, content);

        ValidateResponse(response);
    }
}
