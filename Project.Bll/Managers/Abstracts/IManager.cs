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
    /// Tüm iş mantığı yöneticileri için ortak CRUD ve aggregate işlemlerini tanımlayan generic interface.
    /// Bu interface, veri sorgulama, veri manipülasyonu ve toplu hesaplama işlemlerini kapsar.
    /// </summary>
    /// <typeparam name="T">Veri aktarım nesnesi (DTO) tipi.</typeparam>
    /// <typeparam name="U">Entity tipi, IEntity arayüzünden türemelidir.</typeparam>
    public interface IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        #region Sorgulama İşlemleri (Queries)

        /// <summary>
        /// Tüm kayıtları asenkron olarak getirir.
        /// </summary>
        /// <returns>Tüm DTO listesini asenkron olarak döndürür.</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Belirtilen ID'ye sahip kaydı asenkron olarak getirir.
        /// </summary>
        /// <param name="id">Aranan kaydın ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip DTO'yu asenkron olarak döndürür.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Aktif durumda olan kayıtları getirir.
        /// </summary>
        /// <returns>Aktif DTO listesini döndürür.</returns>
        List<T> GetActives();

        /// <summary>
        /// Pasif (soft-deleted) kayıtları getirir.
        /// </summary>
        /// <returns>Pasif DTO listesini döndürür.</returns>
        List<T> GetPassives();

        /// <summary>
        /// Güncellenmiş (modified) kayıtları getirir.
        /// </summary>
        /// <returns>Güncellenmiş DTO listesini döndürür.</returns>
        List<T> GetModifieds();
        #endregion

        #region Komut İşlemleri (Commands - CRUD)

        /// <summary>
        /// Yeni bir kayıt oluşturur ve veritabanına ekler.
        /// </summary>
        /// <param name="dto">Oluşturulacak DTO nesnesi.</param>
        Task CreateAsync(T dto);

        /// <summary>
        /// Mevcut bir kaydı günceller.
        /// </summary>
        /// <param name="dto">Güncellenecek DTO nesnesi.</param>
        Task UpdateAsync(T dto);

        /// <summary>
        /// Belirtilen kaydı siler ve silme işlemi hakkında bir mesaj döndürür.
        /// </summary>
        /// <param name="dto">Silinecek DTO nesnesi.</param>
        /// <returns>Silme işleminin sonucunu açıklayan mesaj.</returns>
        Task<string> RemoveAsync(T dto);

        /// <summary>
        /// Belirtilen kaydı pasif (soft-delete) hale getirir.
        /// </summary>
        /// <param name="dto">Pasif hale getirilecek DTO nesnesi.</param>
        Task MakePassiveAsync(T dto);

        /// <summary>
        /// Birden fazla kayıt için toplu ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="dtoList">Eklenmek istenen DTO nesnelerinin listesi.</param>
        Task CreateRangeAsync(List<T> dtoList);

        /// <summary>
        /// Birden fazla kayıt için toplu güncelleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="dtoList">Güncellenecek DTO nesnelerinin listesi.</param>
        Task UpdateRangeAsync(List<T> dtoList);

        /// <summary>
        /// Birden fazla kaydı toplu olarak siler ve silme işlemi hakkında bir mesaj döndürür.
        /// </summary>
        /// <param name="dtoList">Silinecek DTO nesnelerinin listesi.</param>
        /// <returns>Silme işleminin sonucunu açıklayan mesaj.</returns>
        Task<string> RemoveRangeAsync(List<T> dtoList);
        #endregion

        #region Aggregate İşlemleri

        /// <summary>
        /// Belirtilen koşula uyan kayıtların sayısını asenkron olarak döndürür.
        /// </summary>
        /// <param name="predicate">Sayma işlemi için kullanılacak koşul ifadesi (opsiyonel).</param>
        /// <returns>Koşula uyan kayıt sayısı.</returns>
        Task<int> CountAsync(Expression<Func<U, bool>> predicate = null);

        /// <summary>
        /// Seçiciye göre, belirtilen koşula uyan kayıtların toplam değerini asenkron olarak döndürür.
        /// </summary>
        /// <param name="selector">Toplama işlemi için kullanılacak değer seçici ifadesi.</param>
        /// <param name="predicate">Toplama işlemi için kullanılacak koşul ifadesi (opsiyonel).</param>
        /// <returns>Toplam değer.</returns>
        Task<decimal> SumAsync(Expression<Func<U, decimal>> selector, Expression<Func<U, bool>> predicate = null);
        #endregion
    }
}
