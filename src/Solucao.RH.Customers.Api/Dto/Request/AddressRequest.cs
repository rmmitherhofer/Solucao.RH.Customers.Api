using System.ComponentModel.DataAnnotations;

namespace Solucao.RH.Customers.Api.Dto.Request;

public class AddressRequest
{
    /// <summary>
    /// Logradouro - Nome da Rua, Avenida, Estrada do endereço
    /// </summary>
    [StringLength(150, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string Street { get; set; }
    /// <summary>
    /// Numero - Numero ou identificação do imóvel
    /// </summary>
    [StringLength(10, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Number { get; set; }
    /// <summary>
    /// Complemento - Complemento ou referencia do imóvel
    /// </summary>
    [StringLength(60, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? Complement { get; set; }
    /// <summary>
    /// Bairro
    /// </summary>
    [StringLength(120, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? District { get; set; }
    /// <summary>
    /// CEP
    /// </summary>
    [StringLength(10, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string? ZipCode { get; set; }
    /// <summary>
    /// Cidade
    /// </summary>
    [Required(ErrorMessage ="O campo {0} é obrigatório")]
    [StringLength(120, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string City { get; set; }
    /// <summary>
    /// Estado
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(120, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string State { get; set; }
    /// <summary>
    /// País
    /// </summary>    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(120, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
    public string Country { get; set; }
}


public class AddAddressRequest : AddressRequest { }


public class UpdateAddressRequest : AddressRequest { }
