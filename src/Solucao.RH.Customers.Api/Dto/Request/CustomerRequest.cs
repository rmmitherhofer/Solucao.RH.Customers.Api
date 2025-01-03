using Solucao.RH.Customers.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace Solucao.RH.Customers.Api.Dto.Request;

public abstract class CustomerRequest
{
    /// <summary>
    /// Numero do telefone
    /// </summary>
    [StringLength(15, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Telephone { get; set; }
    /// <summary>
    /// Numero do celular
    /// </summary>
    [StringLength(15, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Cellphone { get; set; }
    /// <summary>
    /// E-mail de contato
    /// </summary>
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    [StringLength(254, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Email { get; set; }
    /// <summary>
    /// Site da empresa
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Site { get; set; }
    /// <summary>
    /// Data da Fundação
    /// </summary>
    public DateTime? FoundationDate { get; set; }
    /// <summary>
    /// Numero do registro estadual
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? StateRegistration { get; set; }
    /// <summary>
    /// Numero do registro municipal
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? MunicipalRegistration { get; set; }
    /// <summary>
    /// Segmento de atuação
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Segment { get; set; }
    /// <summary>
    /// Porte da companhia
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? CompanySize { get; set; }
    /// <summary>
    /// Id do usuario vinculado
    /// </summary>    
    public Guid? UserId { get; set; }
    /// <summary>
    /// Status do cadastro
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Status Status { get; set; }
    /// <summary>
    /// Area de negocio
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? BusinessArea { get; set; }
    /// <summary>
    /// Classificação
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Classification { get; set; }
    /// <summary>
    /// Tipo da empresa
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Type { get; set; }
    /// <summary>
    /// Origem do cadastro
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Origin { get; set; }
}

public class AddCustomerRequest : CustomerRequest
{
    /// <summary>
    /// CNPJ
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(18, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 14)]
    public string Cnpj { get; set; }
    /// <summary>
    /// Nome da empresa
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string Name { get; set; }
}

public class UpdateCustomerRequest : CustomerRequest { }