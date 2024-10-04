using Api.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class CustomersPaginatedResponse : PaginatedResponse
{
    /// <summary>
    /// Lista de candidatos
    /// </summary>
    public IEnumerable<CustomerResponse> Customers { get; set; }

    /// <summary>
    /// Lista de clientes paginados
    /// </summary>
    /// <param name="totalRecords">Total de registros</param>
    /// <param name="pageNumber">Numero da página</param>
    /// <param name="pageCount">Quantidade de páginas</param>
    /// <param name="customers">Lista de Clientes</param>
    public CustomersPaginatedResponse(int totalRecords,
        int pageNumber,
        int pageCount,
        IEnumerable<CustomerResponse> customers) :
        base(totalRecords, pageNumber, pageCount, customers.Count()) => Customers = customers;

}
