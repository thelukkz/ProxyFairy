using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;

namespace ProxyFairy.Core.Service.Concrete
{
    public class AppParameterManager : BusinessManager, ICustomerManager
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

        public AppParameterManager(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            AppParameter parameter = (AppParameter)entity;
            _repository.Create(parameter);
        }

        public void Delete(BaseEntity entity)
        {
            AppParameter parameter = (AppParameter)entity;
            _repository.Delete(parameter);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<AppParameter>().ToList<AppParameter>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            AppParameter parameter = (AppParameter)entity;
            _repository.Update<AppParameter>(parameter);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
