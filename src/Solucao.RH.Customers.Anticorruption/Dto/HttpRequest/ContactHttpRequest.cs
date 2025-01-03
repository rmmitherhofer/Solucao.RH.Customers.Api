using Common.Core.Enums;
using Solucao.RH.Customers.Business.Enums;

namespace Solucao.RH.Customers.Anticorruption.Dto.HttpRequest;

public class ContactHttpRequest
{
    /// <summary>
    /// Id do contato
    /// </summary>
    public Guid ContactId { get; set; }
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