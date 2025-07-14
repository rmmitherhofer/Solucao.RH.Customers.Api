using Solucao.RH.Customers.Business.Enums;
using Zypher.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

public class CustomerResponse : Response
{
    /// <summary>
    /// Id do cliente
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Codigo do cliente
    /// </summary>
    public long Code { get; set; }
    /// <summary>
    /// CNPJ
    /// </summary>
    public string Cnpj { get; set; }
    /// <summary>
    /// Nome da empresa
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Numero do telefone
    /// </summary>
    public string? Telephone { get; set; }
    /// <summary>
    /// Numero do celular
    /// </summary>
    public string? Cellphone { get; set; }
    /// <summary>
    /// E-mail de contato
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// Site da empresa
    /// </summary>
    public string? Site { get; set; }
    /// <summary>
    /// Data da Fundação
    /// </summary>
    public DateTime? FoundationDate { get; set; }
    /// <summary>
    /// Numero do registro estadual
    /// </summary>
    public string? StateRegistration { get; set; }
    /// <summary>
    /// Numero do registro municipal
    /// </summary>
    public string? MunicipalRegistration { get; set; }
    /// <summary>
    /// Segmento de atuação
    /// </summary>
    public string? Segment { get; set; }
    /// <summary>
    /// Porte da companhia
    /// </summary>
    public string? CompanySize { get; set; }
    /// <summary>
    /// Id do usuario vinculado
    /// </summary>
    public Guid? UserId { get; set; }
    /// <summary>
    /// Status do cadastro
    /// </summary>
    public Status Status { get; set; }
    /// <summary>
    /// Area de negocio
    /// </summary>
    public string? BusinessArea { get; set; }
    /// <summary>
    /// Classificação
    /// </summary>
    public string? Classification { get; set; }
    /// <summary>
    /// Tipo da empresa
    /// </summary>
    public string? Type { get; set; }
    /// <summary>
    /// Origem do cadastro
    /// </summary>
    public string? Origin { get; set; }

    /// <summary>
    /// Lista de endereços
    /// </summary>
    public IEnumerable<AddressResponse> Addresses { get; set; }
    /// <summary>
    /// Lista de contatos
    /// </summary>
    public IEnumerable<ContactResponse> Contacts { get; set; }

}
