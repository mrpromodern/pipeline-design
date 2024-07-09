using System.Collections.Generic;

namespace PipelineDesign.Repositories
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
        void DeleteMany(IEnumerable<T> entities);
        void Save();
    }
}
