using Zypher.Domain.Core.Enums;

namespace Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;

public class CustomerHttpRequest
{
    /// <summary>
    /// ID do cliente
    /// </summary>
    public Guid CustomerId { get; set; }
    /// <summary>
    /// Código do cliente
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
    public int Status { get; set; }
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
    /// Data de registro
    /// </summary>
    public DateTime RegistrationDate { get; set; }
    /// <summary>
    /// Data de alteração
    /// </summary>
    public DateTime? DateChanged { get; set; }
    /// <summary>
    /// Tipo de operação I Inclusao, U atualização, D Remoção
    /// </summary>
    public OperationType OperationType { get; set; }
}