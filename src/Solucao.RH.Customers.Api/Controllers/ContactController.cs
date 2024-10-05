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
[Route("api/v{version:ApiVersion}/customer/{customerId}/contact")]
public class ContactController : MainController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public ContactController(INotificationHandler notification, ICustomerRepository customerRepository, IMapper mapper) : base(notification)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Serviço que obtem todos os contatos de um cliente/empresa cadastrada em forma de lista")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ContactResponse>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Get(Guid customerId)
        => CustomResponse(_mapper.Map<IEnumerable<ContactResponse>>((await _customerRepository.GetById(customerId)).Contacts));

    [HttpPost]
    [SwaggerOperation(Summary = "Serviço para cadastrar um novo contato para um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Post(Guid customerId, AddContactRequest request)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} nao localizado.");
            return CustomResponse();
        }

        customer.AddContact(request.Name, request.Telephone, request.CellPhone, request.WhatsApp, request.Email, request.Department, request.Position);

        _customerRepository.Update(customer);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }

    [HttpPut("{contactId}")]
    [SwaggerOperation(Summary = "Serviço para alterar os dados de um contato existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Put(Guid customerId, Guid contactId, UpdateContactRequest request)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} nao localizado.");
            return CustomResponse();
        }

        var contact = customer.Contacts.FirstOrDefault(x => x.Id == contactId);

        if (contact is null)
        {
            Notify(nameof(contactId), $"Contato {contactId} não localizado.");
            return CustomResponse();
        }

        contact.Update(request.Telephone, request.CellPhone, request.WhatsApp, request.Email, request.Department, request.Position);

        _customerRepository.Update(contact);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }

    [HttpDelete("{contactId}")]
    [SwaggerOperation(Summary = "Serviço para remover os dados de contato de um cliente/empresa existente")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Delete(Guid customerId, Guid contactId)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer is null)
        {
            Notify(nameof(customerId), $"Cliente {customerId} não localizado.");
            return CustomResponse();
        }

        var contact = customer.Contacts.FirstOrDefault(c => c.Id == contactId);

        if (contact is null)
        {
            Notify(nameof(contactId), $"Contato {contactId} não localizado.");
            return CustomResponse();
        }

        _customerRepository.Remove(contact);

        await _customerRepository.UnitOfWork.Commit();

        return CustomResponse();
    }
}