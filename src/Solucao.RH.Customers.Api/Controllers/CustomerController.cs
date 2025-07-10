using Api.Responses;
using Api.Service.Controllers;
using AutoMapper;
using Common.Core.Enums;
using Common.Core.ValueObjects;
using Common.Logs.Extensions;
using Common.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Solucao.RH.Customers.Api.Dto.Request;
using Solucao.RH.Customers.Api.Dto.Responses;
using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Interfaces.HttpServices;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Business.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Solucao.RH.Customers.Api.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:ApiVersion}/customers")]
public class CustomerController : MainController
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerHistHttpService _customerHistHttpService;
    private readonly IMapper _mapper;

    public CustomerController(INotificationHandler notification,
        ICustomerRepository customerRepository,
        IMapper mapper,
        ICustomerHistHttpService customerHistHttpService,
        ILogger<CustomerController> logger) : base(notification)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _customerHistHttpService = customerHistHttpService;
        _logger = logger;
    }

    [HttpGet]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomersPaginatedResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
    public async Task<IActionResult> Get([FromQuery] CustomerFilterRequest request)
    {
        var (customers, pageCount, totalRecords) = await _customerRepository.GetPaginated(_mapper.Map<CustomerFilter>(request));

        CustomersPaginatedResponse response = new(totalRecords, request.PageNumber, pageCount, _mapper.Map<IEnumerable<CustomerResponse>>(customers));

        return CustomResponse(response);
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerResponse))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await _customerRepository.GetById(id);

        if (customer is null)
            return CustomResponse(new NotFoundResponse($"Customer with Id {id} not found"));

        return CustomResponse(_mapper.Map<CustomerResponse>(customer));
    }

    [HttpPost]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
    public async Task<IActionResult> Post(AddCustomerRequest request)
    {
        _logger.LogInfo("Creating customer with Name: {Customer}", request.Name);

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var customer = await _customerRepository.GetByCnpj(new Cnpj(request.Cnpj).Number);

        if (customer is not null)
        {
            Notify(nameof(request.Cnpj), "A customer with this CNPJ already exists.");
            return CustomResponse();
        }

        customer = new Customer(request.Cnpj, request.Name, request.Telephone, request.Cellphone, request.Email, request.Site, request.FoundationDate,
            request.StateRegistration, request.MunicipalRegistration, request.Segment, request.CompanySize, request.UserId, request.Status,
            request.BusinessArea, request.Classification, request.Type, request.Origin);

        _customerRepository.Add(customer);

        var (success, operationType) = await _customerRepository.UnitOfWork.Commit();

        _ = AddHistoric(customer, success, operationType);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
    public async Task<IActionResult> Put(Guid id, UpdateCustomerRequest request)
    {
        _logger.LogInfo("Updating customer with Id: {CustomerId}", id);

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var customer = await _customerRepository.GetById(id);

        if (customer is null)
            return CustomResponse(new NotFoundResponse($"Customer with Id {id} not found"));

        customer.Update(request.Telephone, request.Cellphone, request.Email, request.Site, request.FoundationDate, request.StateRegistration,
            request.MunicipalRegistration, request.Segment, request.CompanySize, request.UserId, request.Status, request.BusinessArea,
            request.Classification, request.Type, request.Origin);

        _customerRepository.Update(customer);

        var (success, operationType) = await _customerRepository.UnitOfWork.Commit();

        _ = AddHistoric(customer, success, operationType);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInfo("Deleting customer with Id: {CustomerId}", id);

        var customer = await _customerRepository.GetById(id);

        if (customer is null)
            return CustomResponse(new NotFoundResponse($"Customer with Id {id} not found"));

        _customerRepository.Remove(customer);

        var (success, operationType) = await _customerRepository.UnitOfWork.Commit();

        _ = AddHistoric(customer, success, operationType);

        return CustomResponse();
    }

    private Task AddHistoric(Customer customer, bool succeded, OperationType operationType)
    {
        if (succeded && operationType != OperationType.None)
            _ = _customerHistHttpService.PostAsync(customer, operationType);

        return Task.CompletedTask;
    }
}