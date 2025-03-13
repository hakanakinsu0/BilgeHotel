using Microsoft.EntityFrameworkCore;
using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System.Linq.Expressions;


namespace Project.Dal.Repositories.Concretes
{
    /// <summary>
    /// Tüm entity'ler için ortak veri erişim işlemlerini sağlayan Generic Repository.
    /// Temel CRUD işlemleri ve dinamik sorgulama desteği sunar.
    /// </summary>
    /// <typeparam name="T">IEntity'den türeyen herhangi bir entity.</typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _context;  // Veritabanı bağlantısı için DbContext. "protected" ile yalnızca türeyen sınıfların erişmesi sağlanır. "readonly" ile nesne ataması yalnızca constructor içinde yapılabilir.
        protected readonly DbSet<T> _dbSet;     // Entity'e ait DbSet nesnesi. "protected" ile türeyen sınıflar erişebilir, "readonly" ile dışarıdan değiştirilemez.

        /// <summary>
        /// BaseRepository constructor'ı, veritabanı bağlantısını ve ilgili DbSet'i başlatır.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public BaseRepository(MyContext context)
        {
            _context = context;         // Constructor üzerinden gelen DbContext nesnesini _context değişkenine atar. Böylece veritabanı işlemleri için kullanılabilir hale gelir.
            _dbSet = _context.Set<T>(); // Generic olarak ilgili entity'nin DbSet'ini belirler. Bu sayede tüm CRUD işlemleri bu DbSet üzerinden gerçekleştirilebilir.
        }

        /// <summary>
        /// Yeni bir kayıt ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity.</param>
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);      // Entity'yi ekler.
            await _context.SaveChangesAsync();  // Veritabanına değişiklikleri kaydeder.
        }

        /// <summary>
        /// Tüm verileri getirir.
        /// </summary>
        /// <returns>Tüm entity listesini döndürür.</returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); // Tüm verileri getirir.
        }

        /// <summary>
        /// Belirtilen ID'ye sahip veriyi getirir.
        /// </summary>
        /// <param name="id">Getirilecek entity'nin ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip entity.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // ID'ye göre entity getirir.
        }

        /// <summary>
        /// Veritabanından belirli bir kaydı siler.
        /// </summary>
        /// <param name="entity">Silinecek entity.</param>
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);              // Entity'yi siler.
            await _context.SaveChangesAsync();  // Değişiklikleri veritabanına kaydeder.
        }

        /// <summary>
        /// Mevcut kaydı günceller.
        /// </summary>
        /// <param name="originalEntity">Güncellenecek entity'nin eski hali.</param>
        /// <param name="newEntity">Güncellenecek yeni entity.</param>
        public async Task UpdateAsync(T originalEntity, T newEntity)
        {
            _context.Entry(originalEntity).CurrentValues.SetValues(newEntity);  // Güncellenen değerleri belirler.
            await _context.SaveChangesAsync();                                  // Değişiklikleri kaydeder.
        }

        /// <summary>
        /// Belirli bir koşula göre filtrelenmiş sorgu döndürür.
        /// </summary>
        /// <param name="exp">Filtreleme işlemi için Expression.</param>
        /// <returns>Filtrelenmiş IQueryable koleksiyonu.</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp); // Dinamik koşula göre sorgu oluşturur.
        }
    }
}