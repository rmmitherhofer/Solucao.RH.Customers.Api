using System.ComponentModel.DataAnnotations;

namespace Solucao.RH.Customers.Api.Dto.Request;

public class ContactRequest
{
    /// <summary>
    /// Numero do telefone
    /// </summary>
    [StringLength(15, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Telephone { get; set; }
    /// <summary>
    /// Numero de celular
    /// </summary>
    [StringLength(15, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? CellPhone { get; set; }
    /// <summary>
    /// Numero de Whatsapp
    /// </summary>
    [StringLength(15, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? WhatsApp { get; set; }
    /// <summary>
    /// Endereço de e-mail
    /// </summary>
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    [StringLength(254, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Email { get; set; }
    /// <summary>
    /// Departamento de atuação
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Department { get; set; }
    /// <summary>
    /// Posição ou cargo do responsavel
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Position { get; set; }
}

public class AddContactRequest : ContactRequest
{
    /// <summary>
    /// Nome do contato
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string Name { get; set; }
}

public class UpdateContactRequest : ContactRequest { }