using Solucao.RH.Customers.Business.Models;
using Zypher.Domain.Core.Enums;

namespace Solucao.RH.Customers.Business.Interfaces.HttpServices;

public interface ICustomerHistHttpService
{
    Task PostAsync(Customer request, OperationType operationType);
    Task PostAsync(Contact request, OperationType operationType);
    Task PostAsync(Address request, OperationType operationType);
}
