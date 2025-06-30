using System.ComponentModel;

namespace Solucao.RH.Customers.Business.Enums;

public enum Status
{
    [Description("Custumer Active")]

    Active = 1,
    [Description("Custumer Inactive")]
    Inactive = 2,

    /// <summary>
    /// Apenas um teste
    /// </summary>
    TesteEnum = 3,
}
