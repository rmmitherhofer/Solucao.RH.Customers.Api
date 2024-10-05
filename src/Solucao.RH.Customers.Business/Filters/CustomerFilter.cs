using Api.Core.Data.Filters;

namespace Solucao.RH.Customers.Business.Filters;

public class CustomerFilter : Filter
{
    public string? Cnpj { get; set; }
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
