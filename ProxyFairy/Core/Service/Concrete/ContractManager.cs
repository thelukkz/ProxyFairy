using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.Core.Service.Dtos.Contract;
using ProxyFairy.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace ProxyFairy.Core.Service.Concrete
{
    public class ContractManager : BusinessManager, IContractManager
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork{
            get{
                return _unitOfWork;
            }
        }

        public ContractManager(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            Contract contract = (Contract)entity;
            _repository.Create<Contract>(contract);
        }

        public void Delete(BaseEntity entity)
        {
            Contract contract = (Contract)entity;
            _repository.Delete<Contract>(contract);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Contract>().ToList<Contract>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(BaseEntity entity)
        {
            Contract contract = (Contract)entity;
            _repository.Update<Contract>(contract);
            SaveChanges();
        }

        public void CreateContract(ContractDto contractDto)
        {
            if (IsSlotTaken(contractDto.SlotId.Value, contractDto.Year, contractDto.Month))
             throw new ContractAttachToSlotException();

            Contract contract = new Contract{
                Year = contractDto.Year,
                Month = contractDto.Month,
                ServiceDesk = contractDto.ServiceDesk,
                CreatedOn = DateTime.UtcNow
            };

            if (contractDto.MobAppId.HasValue) contract.MobAppId = contractDto.MobAppId.Value;
            if (contractDto.SlotId.HasValue) contract.SlotId = contractDto.SlotId.Value;

            _repository.Create<Contract>(contract);
            SaveChanges();
        }
        
        private bool IsSlotAvailable(long slotId)
        {
            return _repository.All<Slot>().Any(x => x.Id == slotId);
        }
        private bool IsSlotTaken(long slotId, int year, int month)
        {
            return _repository.All<Contract>().Any(x => 
                x.SlotId == slotId &&
                x.Year == year &&
                x.Month == month);
        }
        public void UpdateContract(ContractDto contractDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContract(long contractId)
        {
            throw new System.NotImplementedException();
        }

        public void RenewContractForNextMonth(long contractId)
        {
            throw new System.NotImplementedException();
        }

        public ContractDto GetCurrentContract(long slotId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ContractDto>> GetAllContractsAsync(long slotId)
        {
            return await _repository.All<Contract>()
                .Where(x => x.SlotId == slotId)
                .Select(x => new ContractDto{
                    Id = x.Id,
                    MobAppId = x.MobAppId,
                    SlotId = x.SlotId,
                    ServiceDesk = x.ServiceDesk,
                    Month = x.Month,
                    Year = x.Year
                })
                .ToListAsync();
        }
    }
}