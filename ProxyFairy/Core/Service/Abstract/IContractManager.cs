using System.Collections.Generic;
using ProxyFairy.Core.Service.Dtos.Contract;
using System.Threading.Tasks;

namespace ProxyFairy.Core.Service.Abstract
{
    public interface IContractManager : IActionManager
    {
        void CreateContract(ContractDto contractDto);
        void UpdateContract(ContractDto contractDto);
        void DeleteContract(long contractId);
        void RenewContractForNextMonth(long contractId);
        ContractDto GetCurrentContract(long slotId);
        Task<List<ContractDto>> GetAllContractsAsync(long slotId);
    }
}