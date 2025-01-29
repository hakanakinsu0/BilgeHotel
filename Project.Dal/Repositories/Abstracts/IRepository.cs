using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Tüm entity’ler için temel CRUD işlemlerini sağlayan generic repository interface’i.
    /// </summary>
    /// <typeparam name="T">IEntity’den türeyen herhangi bir entity.</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        // Queries (Veri Çekme İşlemleri)
        Task<List<T>> GetAllAsync(); // Tüm verileri getir.
        Task<T> GetByIdAsync(int id); // ID'ye göre veri getir.
        IQueryable<T> Where(Expression<Func<T, bool>> exp); // Dinamik filtreleme yap.

        // Command (Veri Manipülasyon İşlemleri)
        Task CreateAsync(T entity); // Yeni kayıt ekle.
        Task RemoveAsync(T entity); // Kaydı sil.
        Task UpdateAsync(T originalEntity, T newEntity); // Kaydı güncelle.
    }
}
