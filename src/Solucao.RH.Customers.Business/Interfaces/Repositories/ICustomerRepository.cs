using Api.Core.Data;
using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Business.Interfaces.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    public Task<(IEnumerable<Customer> customers, int pageCount, int totalRecords)> GetPaginated(CustomerFilter filter);
    public Task<Customer> GetByCnpj(string cnpj);

    void Add(Address address);
    void Update(Address address);
    void Remove(Address address);

    void Add(Contact contact);
    void Update(Contact contact);
    void Remove(Contact contact);

}
