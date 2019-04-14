using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.Core.Service.Dtos.MobApp;

namespace ProxyFairy.Core.Service.Concrete
{
    public class SlotManager : BusinessManager, ISlotManager
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork{
            get
            {
                return _unitOfWork;
            }
        }

        public SlotManager(IRepository repository, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Create(BaseEntity entity)
        {
            Slot slot = (Slot)entity;
            _repository.Create<Slot>(slot);
        }

        public void Delete(BaseEntity entity)
        {
            Slot slot = (Slot)entity;
            _repository.Delete<Slot>(slot);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Slot>().ToList<Slot>();
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
            Slot slot = (Slot)entity;
            _repository.Update<Slot>(slot);
            SaveChanges();
        }
    }
}