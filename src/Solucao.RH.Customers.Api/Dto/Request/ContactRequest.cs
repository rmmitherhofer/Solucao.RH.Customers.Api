namespace Solucao.RH.Customers.Api.Dto.Request;

public abstract class ContactRequest
{
    /// <summary>
    /// Nome do contato
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Numero do telefone
    /// </summary>
    public string? Telephone { get; set; }
    /// <summary>
    /// Numero de celular
    /// </summary>
    public string? CellPhone { get; set; }
    /// <summary>
    /// Numero de Whatsapp
    /// </summary>
    public string? WhatsApp { get; set; }
    /// <summary>
    /// Endereço de e-mail
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// Departamento de atuação
    /// </summary>
    public string? Department { get; set; }
    /// <summary>
    /// Posição ou cargo do responsavel
    /// </summary>
    public string? Position { get; set; }
}

public class AddContactRequest : ContactRequest { }

public class UpdateContactRequest : ContactRequest
{
    /// <summary>
    /// Id do cliente
    /// </summary>
    public Guid CustomerId { get; set; }
}