using Solucao.RH.Customers.Business.Filters;
using Solucao.RH.Customers.Business.Models;

namespace Solucao.RH.Customers.Data.Extensions;

public static class FilterExtensions
{
    public static IQueryable<Customer> Filter(this IQueryable<Customer> query, CustomerFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(c => c.Name.Trim().ToLower().Contains(filter.Name.Trim().ToLower()));

        if (!string.IsNullOrEmpty(filter.Cnpj))
            query = query.Where(c => c.Cnpj.Trim().ToLower().Contains(filter.Cnpj.Trim().ToLower()));

        if (!string.IsNullOrEmpty(filter.Email))
            query = query.Where(c => c.Email.Trim().ToLower().Contains(filter.Email.Trim().ToLower()));

        if (!string.IsNullOrEmpty(filter.Telephone))
            query = query.Where(c => c.Telephone.Trim().ToLower().Contains(filter.Telephone.Trim().ToLower()));

        if (!string.IsNullOrEmpty(filter.Cellphone))
            query = query.Where(c => c.Cellphone.Trim().ToLower().Contains(filter.Cellphone.Trim().ToLower()));        

        if (filter.StartDate.HasValue)
            query = query.Where(c => c.RegistrationDate >= filter.StartDate.Value);

        if (filter.EndDate.HasValue)
            query = query.Where(c => c.RegistrationDate <= filter.EndDate.Value);

        return query;
    }
}
