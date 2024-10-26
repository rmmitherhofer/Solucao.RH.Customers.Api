using Api.Responses;
using Api.Service.Controllers;
using AutoMapper;
using Common.Notifications.Interfaces;
using Core.ValueObjects;
using Extensoes;
using Microsoft.AspNetCore.Mvc;
using Solucao.RH.Customers.Api.Dto.Request;
using Solucao.RH.Customers.Api.Dto.Responses;
using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Business.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Solucao.RH.Customers.Api.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:ApiVersion}/customer")]
public class CustomerController : MainController
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController(INotificationHandler notification, ILogger<CustomerController> logger, ICustomerRepository customerRepository, IMapper mapper) : base(notification)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Serviço que obtem todos os clientes/empresas cadastradas em forma de lista")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CustomerResponse>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Get() 
        => CustomResponse(_mapper.Map<IEnumerable<CustomerResponse>>(await _customerRepository.GetAll()));

    [HttpGet("paginate")]
    [SwaggerOperation(Summary = "Serviço que obtem todos os clientes/empresas cadastradas em forma de lista paginada")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomersPaginatedResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Get([FromQuery] CustomerFilterRequest request)
    {
        var (customers, pageCount, totalRecords) = await _customerRepository.GetPaginated(_mapper.Map<CustomerFilter>(request));

        CustomersPaginatedResponse response = new(totalRecords, request.PageNumber, pageCount, _mapper.Map<IEnumerable<CustomerResponse>>(customers));

        return CustomResponse(response);
    }

    [HttpGet("{customerId}")]
    [SwaggerOperation(Summary = "Serviço para obter um cliente/empresa atraves do ID")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Get(Guid customerId) 
        => CustomResponse(_mapper.Map<CustomerResponse>(await _customerRepository.GetById(customerId)));

    [HttpPost]
    [SwaggerOperation(Summary = "Serviço para cadastrar um novo cliente/empresa")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Post(AddCustomerRequest request)
    {
        var customer = await _customerRepository.GetByCnpj(new Cnpj(request.Cnpj).Number);

        if (customer is not null)
        {
            Notify(nameof(request.Cnpj), $"Cliente portador do CNPJ {request.Cnpj.CnpjMask()} ja cadastrado na base de dados.");
            return CustomResponse();
        }

        customer = new Customer(request.Cnpj, request.Name, request.Telephone, request.Cellphone, request.Email, request.Site, request.FoundationDate, 
            request.StateRegistration, request.MunicipalRegistration, request.Segment, request.CompanySize, request.UserId, request.Status, 
            request.BusinessArea, request.Classification, request.Type, request.Origin);

        foreach (var address in request.Addresses)
        {
            customer.AddAddress(address.Street, address.Number, address.Complement, address.District, address.ZipCode, address.City, address.State, address.Country);
        }

        foreach (var contact in request.Contacts)
        {
            customer.AddContact(contact.Name, contact.Telephone, contact.CellPhone, contact.WhatsApp, contact.Email, contact.Department, contact.Position);
        }

        _customerRepository.Add(customer);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }

    [HttpPut("{customerId}")]
    [SwaggerOperation(Summary = "Serviço para alterar os dados de um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Put(Guid customerId, UpdateCustomerRequest request)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} nao localizado.");
            return CustomResponse();
        }

        customer.Update(request.Telephone, request.Cellphone, request.Email, request.Site, request.FoundationDate, request.StateRegistration, 
            request.MunicipalRegistration, request.Segment, request.CompanySize, request.UserId, request.Status, request.BusinessArea, 
            request.Classification, request.Type, request.Origin);

        _customerRepository.Update(customer);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }

    [HttpDelete("{customerId}")]
    [SwaggerOperation(Summary = "Serviço para remover os dados de um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} nao localizado.");
            return CustomResponse();
        }

        _customerRepository.Remove(customer);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }    
}