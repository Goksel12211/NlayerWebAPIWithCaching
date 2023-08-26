using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        // Best Practise açısından her asenkron fonksyionun sonuna "Async" konulmalı !
        // EX USAGE: productRepository.where(x=>x.id>5).OrderBy.ToListAsync();
        // Böylece OrderBy işlemi database'e sorgu atılırken kullanılır . Veri geldikten sonra değil ! 
        IQueryable<T> Where(Expression<Func<T,bool>> expression); // Asenkron olmamasının nedeni sorgu yapılmamamsı , sadece sorgu oluşturulması !
        Task AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); 
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        // Update ve Remove asenkron olmamalı !!!!! EF arka planda kendisi hallediyor !
    }
}
