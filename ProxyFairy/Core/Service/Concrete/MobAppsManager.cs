using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.Core.Service.Dtos.MobApp;

namespace ProxyFairy.Core.Service.Concrete
{
    public class MobAppsManager : BusinessManager, IMobAppsManager
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
        public MobAppsManager(IRepository repository, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OutMobAppDto>> GetAllMobAppsAsync()
        {
            var result = new List<OutMobAppDto>();
            var apps = await _repository.All<MobApp>()
                .Include(x => x.Customer)
                .Include(x => x.Customer.ProductOwner)
                .ToListAsync<MobApp>();
            if (apps.Any())
            {
                result = apps.Select(x => new OutMobAppDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    AppBundle = x.AppBundle,
                    Platform = x.Platform,
                    ProductOwner = new ProductOwnerDto
                    {
                        Id = x.Customer != null
                            ? x.Customer.ProductOwner != null ? x.Customer.ProductOwner.Id : null
                            : null,
                        FullName = x.Customer != null
                            ? x.Customer.ProductOwner != null ? x.Customer.ProductOwner.UserName : null
                            : null
                    },
                    Customer = new CustomerDto
                    {
                        Id = x.Customer != null ? x.Customer.Id : (long?)null,
                        Name = x.Customer != null ? x.Customer.Name : null
                    }
                }).ToList();
            }
            
            return result;
        }

        public void Create(BaseEntity entity)
        {
            MobApp mobApp = (MobApp)entity;
            _repository.Create<MobApp>(mobApp);
        }

        public void Update(BaseEntity entity)
        {
            MobApp mobApp = (MobApp)entity;
            _repository.Update<MobApp>(mobApp);
            SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            MobApp mobApp = (MobApp)entity;
            _repository.Delete<MobApp>(mobApp);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<MobApp>().ToList<MobApp>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
