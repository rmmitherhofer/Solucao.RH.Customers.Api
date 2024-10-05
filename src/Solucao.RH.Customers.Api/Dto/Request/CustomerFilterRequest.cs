using Api.Requests;

namespace Solucao.RH.Customers.Api.Dto.Request;

public class CustomerFilterRequest : FilterRequest
{
    /// <summary>
    /// Filtrar por CNPJ
    /// </summary>
    public string? Cnpj { get; set; }
    /// <summary>
    /// Filtrar por nome
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Filtrar por numero de telefone
    /// </summary>
    public string? Telephone { get; set; }
    /// <summary>
    /// Filtrar por numero de celular
    /// </summary>
    public string? Cellphone { get; set; }
    /// <summary>
    /// Filtrar por e-mail
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Status do cadastro
    /// </summary>
    public string Status { get; set; }
}

