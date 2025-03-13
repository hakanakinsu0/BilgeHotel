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
    /// Veritabanı erişimi için tüm entity’lerde ortak kullanılan Generic Repository interfacei.
    /// Temel CRUD işlemlerini ve dinamik sorgulamayı içerir.
    /// </summary>
    /// <typeparam name="T">IEntity’den türeyen herhangi bir entity.</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        // Queries (Veri Çekme İşlemleri)
        Task<List<T>> GetAllAsync();    // Tüm verileri getir.
        Task<T> GetByIdAsync(int id);   // ID'ye göre veri getir.
        IQueryable<T> Where(Expression<Func<T, bool>> exp); // Belirli bir koşula göre dinamik filtreleme yap.

        // Command (Veri Manipülasyon İşlemleri)
        Task CreateAsync(T entity); // Yeni kayıt ekle.
        Task RemoveAsync(T entity); // Kaydı sil.
        Task UpdateAsync(T originalEntity, T newEntity); // Kaydı güncelle.
    }
}
