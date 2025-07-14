using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;
using Solucao.RH.Customers.Anticorruption.Options;
using Solucao.RH.Customers.Business.Interfaces.HttpServices;
using Solucao.RH.Customers.Business.Models;
using Zypher.Domain.Core.Enums;
using Zypher.Http;
using Zypher.Json;
using Zypher.Logs.Extensions;
using Zypher.Notifications.Interfaces;

namespace Solucao.RH.Customers.Anticorruption.HttpServices;
public class CustomerHistHttpService : HttpService, ICustomerHistHttpService
{
    private readonly CustomerHistorySettings _settings;
    private readonly IMapper _mapper;

    public CustomerHistHttpService(HttpClient httpClient,
        IHttpContextAccessor httpContextAccessor,
        INotificationHandler notification,
        IOptions<CustomerHistorySettings> settings,
        ILogger<CustomerHistHttpService> logger,
        IMapper mapper) : base(httpClient, notification, logger)
    {
        _settings = settings.Value;
        _mapper = mapper;
    }

    public async Task PostAsync(Customer entity, OperationType operationType)
    {
        _logger.LogInfo("Posting customer history for operation type: {OperationType}, CustomerId: {CustomerId}, Name: {Name}", operationType, entity.Id, entity.Name);

        var request = _mapper.Map<CustomerHttpRequest>(entity);

        request.OperationType = operationType;

        var url = _settings.EndPoints.HistCustomer;

        var content = JsonExtensions.SerializeContent(request);

        var response = await PostAsync(url, content);

        ValidateResponse(response);
    }

    public async Task PostAsync(Contact entity, OperationType operationType)
    {        
        _logger.LogInfo("Posting contact history for operation type: {OperationType}, ContactId: {ContactId}, CustomerId: {CustomerId}", operationType, entity.Id, entity.CustomerId);

        var request = _mapper.Map<ContactHttpRequest>(entity);

        request.OperationType = operationType;

        var url = _settings.EndPoints.HistContact;

        var content = JsonExtensions.SerializeContent(request);

        var response = await PostAsync(url, content);

        ValidateResponse(response);
    }

    public async Task PostAsync(Address entity, OperationType operationType)
    {
        _logger.LogInfo("Posting address history for operation type: {OperationType}, AddressId: {AddressId}, CustomerId: {CustomerId}", operationType, entity.Id, entity.CustomerId);

        var request = _mapper.Map<AddressHttpRequest>(entity);

        request.OperationType = operationType;

        var url = _settings.EndPoints.HistContact;

        var content = JsonExtensions.SerializeContent(request);

        var response = await PostAsync(url, content);

        ValidateResponse(response);
    }
}
