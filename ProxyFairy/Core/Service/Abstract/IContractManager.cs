using System.Collections.Generic;
using ProxyFairy.Core.Service.Dtos.Contract;

namespace ProxyFairy.Core.Service.Abstract
{
    public interface IContractManager : IActionManager
    {
        void CreateContract(ContractDto contractDto);
        void UpdateContract(ContractDto contractDto);
        void DeleteContract(long contractId);
        void RenewContractForNextMonth(long contractId);
        ContractDto GetCurrentContract(long slotId);
        IEnumerable<ContractDto> GetAllContracts(long slotId);
    }
}