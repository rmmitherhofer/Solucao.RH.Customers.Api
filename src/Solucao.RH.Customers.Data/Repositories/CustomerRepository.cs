using Api.Core;
using Microsoft.EntityFrameworkCore;
using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Business.Models;
using Solucao.RH.Customers.Data.Extensions;
using Api.Data.Extensions;

namespace Solucao.RH.Customers.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRepository(CustomerContext context) => _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<(IEnumerable<Customer> customers, int pageCount, int totalRecords)> GetPaginated(CustomerFilter filter)
    {
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
        var customers =  await _context.Customers
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .ToListAsync();

        return customers;
    }

    public async Task<Customer> GetByCnpj(string cnpj) => await _context.Customers.Where(c => c.Cnpj == cnpj).FirstOrDefaultAsync();
    public async Task<Customer?> GetById(Guid id) => await _context.Customers.FindAsync(id);
    public void Add(Customer customer) => _context.Customers.Add(customer);
    public void Update(Customer customer) => _context.Customers.Update(customer);
    public void Remove(Customer customer) => _context.Customers.Remove(customer);

    public void Add(Address address) => _context.Addresses.Add(address);
    public void Update(Address address) => _context.Addresses.Update(address);
    public void Remove(Address address) => _context.Addresses.Remove(address);

    public void Add(Contact contact) => _context.Contacts.Add(contact);
    public void Update(Contact contact) => _context.Contacts.Update(contact);
    public void Remove(Contact contact) => _context.Contacts.Remove(contact);
    public void Dispose() => _context.Dispose();
}

