namespace Solucao.RH.Customers.Api.Dto.Request;

public class AddressRequest
{
    /// <summary>
    /// Logradouro - Nome da Rua, Avenida, Estrada do endereço
    /// </summary>
    public string Street { get; set; }
    /// <summary>
    /// Numero - Numero ou identificação do imóvel
    /// </summary>
    public string? Number { get; set; }
    /// <summary>
    /// Complemento - Complemento ou referencia do imóvel
    /// </summary>
    public string? Complement { get; set; }
    /// <summary>
    /// Bairro
    /// </summary>
    public string? District { get; set; }
    /// <summary>
    /// CEP
    /// </summary>
    public string? ZipCode { get; set; }
    /// <summary>
    /// Cidade
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Estado
    /// </summary>
    public string State { get; set; }
    /// <summary>
    /// Pais
    /// </summary>
    public string Country { get; set; }
}


public class AddAddressRequest : AddressRequest { }


public class UpdateAddressRequest : AddressRequest { }
