using Api.Responses;
using Api.Service.Controllers;
using AutoMapper;
using Common.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Solucao.RH.Customers.Api.Dto.Request;
using Solucao.RH.Customers.Api.Dto.Responses;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Solucao.RH.Customers.Api.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:ApiVersion}/customer/{customerId}/address")]
public class AddressController : MainController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public AddressController(INotificationHandler notification, ICustomerRepository customerRepository, IMapper mapper) : base(notification)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Serviço que obtem todos os endereços de um cliente/empresa cadastrada em forma de lista")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AddressResponse>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Get(Guid customerId)
        => CustomResponse(_mapper.Map<IEnumerable<AddressResponse>>((await _customerRepository.GetById(customerId)).Addresses));

    [HttpPost]
    [SwaggerOperation(Summary = "Serviço para cadastrar um novo endereço para um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Post(Guid customerId, AddAddressRequest request)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} nao localizado.");
            return CustomResponse();
        }

        customer.AddAddress(request.Street, request.Number, request.Complement, request.District, request.ZipCode, request.City, request.State);

        _customerRepository.Update(customer);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }
   
    [HttpPut("{addressId}")]
    [SwaggerOperation(Summary = "Serviço para alterar os dados de um endereço existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Put(Guid customerId, Guid addressId, UpdateAddressRequest request)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} não localizado.");
            return CustomResponse();
        }

        var address = customer.Addresses.FirstOrDefault(x => x.Id == addressId);

        if (address is null)
        {
            Notify(nameof(addressId), $"Endereço {addressId} não localizado.");
            return CustomResponse();
        }

        address.Update(request.Street, request.Number, request.Complement, request.District, request.ZipCode, request.City, request.State);

        _customerRepository.Update(address);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }

    [HttpDelete("{addressId}")]
    [SwaggerOperation(Summary = "Serviço para remover um endereço de um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Delete(Guid customerId, Guid addressId)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} não localizado.");
            return CustomResponse();
        }

        var address = customer.Addresses.FirstOrDefault(c => c.Id == addressId);

        if (address is null)
        {
            Notify(nameof(addressId), $"Endereço {addressId} não localizado.");
            return CustomResponse();
        }

        _customerRepository.Remove(address);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }
}