using Solucao.RH.Customers.Business.Enums;
using Zypher.Persistence.Abstractions.Data.Filters;

namespace Solucao.RH.Customers.Business.Filters;

public class CustomerFilter : Filter
{
    public string? Cnpj { get; set; }
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public Status? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
