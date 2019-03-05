using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Enums;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.Core.Service.Dtos.Customer;

namespace ProxyFairy.Core.Service.Concrete
{
    public class CustomerManager : BusinessManager, ICustomerManager
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public CustomerManager(IRepository repository, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _repository.Create<Customer>(customer);
        }

        public void Delete(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _repository.Delete<Customer>(customer);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Customer>().ToList<Customer>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _repository.Update<Customer>(customer);
            SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<OutCustomerDto>> GetAllCustomersAsync()
        {
            var result = await _repository.All<Customer>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Name)
                .Include(x => x.ProductOwner)
                .Include(x => x.MobApps)
                .Select(x => new OutCustomerDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductOwner = new ProductOwnerDto()
                    {
                        Id = x.ProductOwner != null ? x.ProductOwner.Id : null,
                        FullName = x.ProductOwner != null ? x.ProductOwner.UserName : null
                    },
                    DroidAppsCount = x.MobApps != null ? x.MobApps.LongCount(y => y.Platform == Platform.Droid) : 0,
                    IosAppsCount = x.MobApps != null ? x.MobApps.LongCount(y => y.Platform == Platform.iOS) : 0,
                    ActiveSlotsCount = 0 //TODO: calculate active contracts
                })
                .ToListAsync();

            return result;
        }

        public async Task<AppUser> GetProductOwnerAsync(string userId)
        {
            var result = await _repository.SingleAsync<AppUser>(x => x.Id == userId);
            return result;
        }
    }
}
