using Zypher.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class CustomersPaginatedResponse : PaginatedResponse
{
    public IEnumerable<CustomerResponse> Customers { get; set; }

    public CustomersPaginatedResponse(int totalRecords,
        int pageNumber,
        int pageCount,
        IEnumerable<CustomerResponse> customers) :
        base(totalRecords, pageNumber, pageCount, customers.Count()) => Customers = customers;

}
