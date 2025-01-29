using Microsoft.EntityFrameworkCore;
using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using Project.Entities.Interfaces;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    /// <summary>
    /// Tüm entity'ler için ortak veri erişim işlemlerini sağlayan Generic Repository.
    /// </summary>
    /// <typeparam name="T">IEntity'den türeyen herhangi bir entity.</typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Yeni bir kayıt ekler.
        /// </summary>
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Tüm verileri getirir.
        /// </summary>
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye sahip veriyi getirir.
        /// </summary>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Veritabanından belirli bir kaydı siler.
        /// </summary>
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Mevcut kaydı günceller.
        /// </summary>
        public async Task UpdateAsync(T originalEntity, T newEntity)
        {
            _context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Dinamik filtreleme sağlar.
        /// </summary>
        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp);
        }
    }
}