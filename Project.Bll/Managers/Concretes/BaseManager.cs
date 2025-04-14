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
    /// Tüm manager sınıfları için ortak CRUD işlemlerini içeren temel soyut sınıftır.
    /// Bu sınıf, entity nesneleri ve onların DTO karşılıkları arasında dönüşüm yaparak temel iş mantığını yönetir.
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

        // Yeni veri ekleme işlemi
        public async Task CreateAsync(T dto)
        {
            dto.CreatedDate = DateTime.Now;
            dto.Status = DataStatus.Inserted;

            U entity = _mapper.Map<U>(dto); // DTO'yu Entity'ye çevir
            await _repository.CreateAsync(entity); // Repository ile DB'ye kaydet
        }

        // Çoklu veri ekleme
        public async Task CreateRangeAsync(List<T> dtoList)
        {
            foreach (T dto in dtoList)
                await CreateAsync(dto); // Her DTO için CreateAsync çağrılır
        }

        // Tüm verileri getirme (silinmiş dahil)
        public async Task<List<T>> GetAllAsync()
        {
            List<U> entities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(entities);
        }

        // ID'ye göre veri getirme
        public async Task<T> GetByIdAsync(int id)
        {
            U entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        // Aktif (Deleted olmayan) verileri getirir
        public List<T> GetActives()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status != DataStatus.Deleted);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // Sadece silinmiş verileri getirir
        public List<T> GetPassives()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status == DataStatus.Deleted);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // Güncellenmiş verileri getirir
        public List<T> GetModifieds()
        {
            IQueryable<U> entities = _repository.Where(x => x.Status == DataStatus.Updated);
            return _mapper.Map<List<T>>(entities.ToList());
        }

        // Güncelleme işlemi
        public virtual async Task UpdateAsync(T dto)
        {
            U existingEntity = await _repository.GetByIdAsync(dto.Id);

            if (existingEntity == null)
                throw new Exception($"Güncellenecek entity bulunamadı. ID: {dto.Id}");

            dto.ModifiedDate = DateTime.Now;

            if (dto.Status == default)
                dto.Status = DataStatus.Updated;

            U newEntity = _mapper.Map<U>(dto);

            // Durum ve tarih alanları set edilir
            switch (dto.Status)
            {
                case DataStatus.Deleted:
                    newEntity.DeletedDate = DateTime.Now;
                    newEntity.ModifiedDate = null;
                    newEntity.Status = DataStatus.Deleted;
                    break;

                case DataStatus.Updated:
                    newEntity.ModifiedDate = DateTime.Now;
                    newEntity.DeletedDate = null;
                    newEntity.Status = DataStatus.Updated;
                    break;

                default:
                    newEntity.ModifiedDate = DateTime.Now;
                    newEntity.Status = DataStatus.Updated;
                    break;
            }

            await _repository.UpdateAsync(existingEntity, newEntity);
        }

        // Çoklu güncelleme
        public async Task UpdateRangeAsync(List<T> dtoList)
        {
            foreach (T dto in dtoList)
                await UpdateAsync(dto);
        }

        // Soft Delete işlemi (pasife çekme)
        public async Task MakePassiveAsync(T dto)
        {
            U entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.DeletedDate = DateTime.Now;
                entity.Status = DataStatus.Deleted;

                await _repository.UpdateAsync(entity, entity);
            }
        }

        // Kalıcı silme işlemi
        public async Task<string> RemoveAsync(T dto)
        {
            if (dto.Status != DataStatus.Deleted)
                return "Silme işlemi sadece pasif veriler üzerinden yapılabilir.";

            U existingEntity = await _repository.GetByIdAsync(dto.Id);
            await _repository.RemoveAsync(existingEntity);
            return $"Silme işlemi gerçekleştirildi. Silinen ID: {dto.Id}";
        }

        // Çoklu silme işlemi
        public async Task<string> RemoveRangeAsync(List<T> dtoList)
        {
            if (dtoList.Any(x => x.Status != DataStatus.Deleted))
                return "Listede pasif olmayan veriler bulunmaktadır. Lütfen kontrol ediniz.";

            foreach (T dto in dtoList)
                await RemoveAsync(dto);

            return "Liste başarıyla silindi.";
        }

        // Sayma işlemi: filtreli veya filtresiz
        public async Task<int> CountAsync(Expression<Func<U, bool>> predicate = null)
        {
            List<U> entities = await _repository.GetAllAsync();
            return predicate == null
                ? entities.Count
                : entities.Count(predicate.Compile());
        }

        // Toplam alma işlemi: decimal türünde
        public async Task<decimal> SumAsync(Expression<Func<U, decimal>> selector, Expression<Func<U, bool>> predicate = null)
        {
            List<U> entities = await _repository.GetAllAsync();
            return predicate == null
                ? entities.Sum(selector.Compile())
                : entities.Where(predicate.Compile()).Sum(selector.Compile());
        }
    }
}
