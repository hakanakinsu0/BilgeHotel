using Project.Bll.DtoClasses;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Tüm iş mantığı yöneticileri için ortak CRUD işlemlerini tanımlayan generic interface.
    /// </summary>
    public interface IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        // Business Logic For Queries (Sorgulamalar)
        Task<List<T>> GetAllAsync(); // Tüm verileri getirir
        Task<T> GetByIdAsync(int id); // ID’ye göre getirir
        List<T> GetActives(); // Aktif kayıtları getirir
        List<T> GetPassives(); // Pasif kayıtları getirir
        List<T> GetModifieds(); // Güncellenmiş kayıtları getirir

        // Business Logic For Commands (Komutlar - CRUD İşlemleri)
        Task CreateAsync(T dto); // Yeni kayıt ekler
        Task UpdateAsync(T dto); // Mevcut kaydı günceller
        Task<string> RemoveAsync(T dto); // Kaydı siler ve geriye mesaj döndürür
        Task MakePassiveAsync(T dto); // Kaydı pasif hale getirir

        Task CreateRangeAsync(List<T> dtoList); // Toplu ekleme işlemi
        Task UpdateRangeAsync(List<T> dtoList); // Toplu güncelleme işlemi
        Task<string> RemoveRangeAsync(List<T> dtoList); // Toplu silme işlemi
    }
}
