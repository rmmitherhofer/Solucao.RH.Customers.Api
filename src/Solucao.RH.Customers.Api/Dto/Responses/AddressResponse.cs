using Api.Responses;

namespace Solucao.RH.Customers.Api.Dto.Responses;

/// <summary>
/// Endereço
/// </summary>
public class AddressResponse : Response
{
    /// <summary>
    /// Id do endereço
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Logradouro - Nome da Rua, Avenida, Estrada do endereço
    /// </summary>
    public string? Street { get; set; }
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


/// <summary>
/// Endereços
/// </summary>
public class AddressesResponse(Guid customerId)
{
    /// <summary>
    /// Id do cliente
    /// </summary>
    public Guid CustomerId => customerId;
    /// <summary>
    /// Lista de endereços
    /// </summary>
    public ICollection<AddressResponse>? Addresses { get; set; }
}