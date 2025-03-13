using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// Tüm manager sınıfları için ortak CRUD işlemlerini içeren temel soyut sınıf.
    /// </summary>
    public abstract class BaseManager<T, U> : IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        protected readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // **Veri ekleme işlemi**
        public async Task CreateAsync(T dto)
        {
            dto.CreatedDate = DateTime.Now;
            dto.Status = DataStatus.Inserted;

            U entity = _mapper.Map<U>(dto);
            await _repository.CreateAsync(entity);
        }

        public async Task CreateRangeAsync(List<T> dtoList)
        {
            foreach (T dto in dtoList) await CreateAsync(dto);
        }

        // **Tüm verileri getirme işlemi**
        public async Task<List<T>> GetAllAsync()
        {
            List<U> entities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(entities);
        }

        // **ID'ye göre veri getirme işlemi**
        public async Task<T> GetByIdAsync(int id)
        {
            U entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        // **Aktif verileri getirme işlemi**
        public List<T> GetActives()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status != DataStatus.Deleted);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // **Pasif verileri getirme işlemi**
        public List<T> GetPassives()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status == DataStatus.Deleted);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // **Güncellenmiş verileri getirme işlemi**
        public List<T> GetModifieds()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status == DataStatus.Updated);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // **Güncelleme işlemi**
        public async Task UpdateAsync(T dto)
        {
            dto.ModifiedDate = DateTime.Now;
            dto.Status = DataStatus.Updated;

            U newEntity = _mapper.Map<U>(dto);
            U existingEntity = await _repository.GetByIdAsync(newEntity.Id);
            await _repository.UpdateAsync(existingEntity, newEntity);
        }

        public async Task UpdateRangeAsync(List<T> dtoList)
        {
            foreach (T dto in dtoList) await UpdateAsync(dto);
        }

        // **Pasife çekme işlemi**
        //public async Task MakePassiveAsync(T dto)
        //{
        //    dto.DeletedDate = DateTime.Now;
        //    dto.Status = DataStatus.Deleted;

        //    U newEntity = _mapper.Map<U>(dto);
        //    U existingEntity = await _repository.GetByIdAsync(newEntity.Id);
        //    await _repository.UpdateAsync(existingEntity, newEntity);
        //}

        public async Task MakePassiveAsync(T dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.DeletedDate = DateTime.Now;
                entity.Status = DataStatus.Deleted;

                await _repository.UpdateAsync(entity, entity); // ✅ Veritabanında güncelleme yap
            }
        }



        // **Silme işlemi**
        public async Task<string> RemoveAsync(T dto)
        {
            if (dto.Status != DataStatus.Deleted)
            {
                return "Silme işlemi sadece pasif veriler üzerinden yapılabilir.";
            }

            U existingEntity = await _repository.GetByIdAsync(dto.Id);
            await _repository.RemoveAsync(existingEntity);
            return $"Silme işlemi gerçekleştirildi. Silinen ID: {dto.Id}";
        }

        public async Task<string> RemoveRangeAsync(List<T> dtoList)
        {
            if (dtoList.Any(x => x.Status != DataStatus.Deleted))
            {
                return "Listede pasif olmayan veriler bulunmaktadır. Lütfen kontrol ediniz.";
            }

            foreach (T dto in dtoList) await RemoveAsync(dto);
            return "Liste başarıyla silindi.";
        }

        //

        public async Task<int> CountAsync(Expression<Func<U, bool>> predicate = null)
        {
            var entities = await _repository.GetAllAsync();
            return predicate == null
                ? entities.Count  // **GetAllAsync() sonucu liste olduğu için Count() kullanıyoruz**
                : entities.Count(predicate.Compile());  // **Expression<Func<U, bool>>'ı Func<U, bool> haline getiriyoruz**
        }

        public async Task<decimal> SumAsync(Expression<Func<U, decimal>> selector, Expression<Func<U, bool>> predicate = null)
        {
            var entities = await _repository.GetAllAsync();
            return predicate == null
                ? entities.Sum(selector.Compile())  // **GetAllAsync() sonucu liste olduğu için Sum() kullanıyoruz**
                : entities.Where(predicate.Compile()).Sum(selector.Compile());
        }

    }
}
