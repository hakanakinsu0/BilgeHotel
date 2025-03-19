using Project.Bll.DtoClasses;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Tüm iş mantığı yöneticileri için ortak CRUD işlemlerini tanımlayan generic interface.
    /// </summary>
    public interface IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        #region Sorgulama İşlemleri (Queries)

        //////////////// Sorgulama İşlemleri (Queries) ////////////////

        /// <summary>
        /// Tüm verileri getirir.
        /// </summary>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Verilen ID'ye göre kaydı getirir.
        /// </summary>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Aktif kayıtları getirir.
        /// </summary>
        List<T> GetActives();

        /// <summary>
        /// Pasif kayıtları getirir.
        /// </summary>
        List<T> GetPassives();

        /// <summary>
        /// Güncellenmiş kayıtları getirir.
        /// </summary>
        List<T> GetModifieds();
        #endregion

        #region Komut İşlemleri (Commands - CRUD)


        //////////////// Komut İşlemleri (Commands - CRUD) ////////////////

        /// <summary>
        /// Yeni kayıt ekler.
        /// </summary>
        Task CreateAsync(T dto);

        /// <summary>
        /// Mevcut kaydı günceller.
        /// </summary>
        Task UpdateAsync(T dto);

        /// <summary>
        /// Kaydı siler ve geriye mesaj döndürür.
        /// </summary>
        Task<string> RemoveAsync(T dto);

        /// <summary>
        /// Kaydı pasif hale getirir.
        /// </summary>
        Task MakePassiveAsync(T dto);

        /// <summary>
        /// Toplu ekleme işlemi gerçekleştirir.
        /// </summary>
        Task CreateRangeAsync(List<T> dtoList);

        /// <summary>
        /// Toplu güncelleme işlemi gerçekleştirir.
        /// </summary>
        Task UpdateRangeAsync(List<T> dtoList);

        /// <summary>
        /// Toplu silme işlemi gerçekleştirir ve geriye mesaj döndürür.
        /// </summary>
        Task<string> RemoveRangeAsync(List<T> dtoList);
        #endregion

        #region Aggregate İşlemleri

        //////////////// Aggregate İşlemleri ////////////////

        /// <summary>
        /// İstenen koşula uyan kayıtların sayısını döndürür.
        /// </summary>
        Task<int> CountAsync(Expression<Func<U, bool>> predicate = null);

        /// <summary>
        /// Seçiciye göre toplam değeri döndürür.
        /// </summary>
        Task<decimal> SumAsync(Expression<Func<U, decimal>> selector, Expression<Func<U, bool>> predicate = null);
        #endregion
    }
}
