using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;

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
    }
}
