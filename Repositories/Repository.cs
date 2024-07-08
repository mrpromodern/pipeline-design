using PipelineDesign.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PipelineDesign.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context) {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() {
            return _dbSet.ToList();
        }

        public T GetById(string id) {
            return _dbSet.Find(id);
        }

        public void Add(T entity) {
            _dbSet.Add(entity);
        }

        public void Update(T entity) {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(string id) {
            T entity = _dbSet.Find(id);
            if (entity != null) {
                _dbSet.Remove(entity);
            }
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
