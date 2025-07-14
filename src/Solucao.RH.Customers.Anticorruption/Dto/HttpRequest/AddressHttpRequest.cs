using Zypher.Domain.Core.Enums;

namespace Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;

public class AddressHttpRequest
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid AddressId { get; set; }
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
    public string ZipCode { get; set; }
    /// <summary>
    /// Cidade
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Estado
    /// </summary>
    public string State { get; set; }
    /// <summary>
    /// País
    /// </summary>    
    public string Country { get; set; }
    /// <summary>
    /// Removido logicamente
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// Id do cliente
    /// </summary>
    public Guid CustomerId { get; set; }
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