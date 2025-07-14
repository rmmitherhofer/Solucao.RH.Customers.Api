using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Business.Models;
using Solucao.RH.Customers.Data.Extensions;
using Zypher.Logs.Extensions;
using Zypher.Api.Data.Extensions;
using Zypher.Persistence.Abstractions.Data;

namespace Solucao.RH.Customers.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;
    private readonly ILogger<CustomerRepository> _logger;
    public CustomerRepository(CustomerContext context, ILogger<CustomerRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<(IEnumerable<Customer> customers, int pageCount, int totalRecords)> GetPaginated(CustomerFilter filter)
    {
        _logger.LogInfo("Retrieving paginated customers with filter: {@Filter}", filter);

        var query = _context.Customers.Filter(filter);

        var totalRecords = await query.CountAsync();

        int pageCount = filter.GetPageCount(totalRecords);

        var customers = await query
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .OrderBy(filter.OrderBy)
            .Page(filter.PageNumber, filter.PageSize)
            .AsNoTracking()             
            .ToListAsync();

        return (customers, pageCount, totalRecords);
    }
    public async Task<IEnumerable<Customer>?> GetAll()
    {
        _logger.LogInfo("Retrieving all customers");

        return await _context.Customers
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer> GetByCnpj(string cnpj)
    {
        _logger.LogInfo("Retrieving customer by CNPJ: {Cnpj}", cnpj);

        return await _context.Customers.Where(c => c.Cnpj == cnpj)
                .Include(c => c.Addresses)
                .Include(c => c.Contacts)
                .AsNoTracking()
                .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetById(Guid id)
    {
        _logger.LogInfo("Retrieving customer by Id: {Id}", id);

        return await _context.Customers.Where(c => c.Id == id)
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .FirstOrDefaultAsync();
    }

    public void Add(Customer customer)
    {
        _logger.LogInfo("Adding customer with ID: {CustomerId}", customer.Id);

        _context.Customers.Add(customer);
    }

    public void Update(Customer customer)
    {
        _logger.LogInfo("Updating customer with ID: {CustomerId}", customer.Id);

        _context.Customers.Update(customer);
    }

    public void Remove(Customer customer)
    {
        _logger.LogInfo("Removing customer with ID: {CustomerId}", customer.Id);

        _context.Customers.Remove(customer);
    }

    public void Add(Address address)
    {
        _logger.LogInfo("Adding address for customer with ID: {CustomerId}", address.CustomerId);

        _context.Addresses.Add(address);
    }

    public void Update(Address address)
    {
        _logger.LogInfo("Updating address with ID: {AddressId} for customer with ID: {CustomerId}", address.Id, address.CustomerId);

        _context.Addresses.Update(address);
    }

    public void Remove(Address address)
    {
        _logger.LogInfo("Removing address with ID: {AddressId} for customer with ID: {CustomerId}", address.Id, address.CustomerId);

        _context.Addresses.Remove(address);
    }

    public void Add(Contact contact)
    {
        _logger.LogInfo("Adding contact for customer with ID: {CustomerId}", contact.CustomerId);

        _context.Contacts.Add(contact);
    }

    public void Update(Contact contact)
    {
        _logger.LogInfo("Updating contact with ID: {ContactId} for customer with ID: {CustomerId}", contact.Id, contact.CustomerId);

        _context.Contacts.Update(contact);
    }

    public void Remove(Contact contact)
    {
        _logger.LogInfo("Removing contact with ID: {ContactId} for customer with ID: {CustomerId}", contact.Id, contact.CustomerId);

        _context.Contacts.Remove(contact);
    }

    public void Dispose() => _context.Dispose();
}

