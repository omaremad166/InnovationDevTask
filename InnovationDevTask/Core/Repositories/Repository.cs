using InnovationDevTask.Core.IRepositories;
using InnovationDevTask.Data;
using Microsoft.EntityFrameworkCore;

namespace InnovationDevTask.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InnovationDevTaskContext _context;
        public Repository(InnovationDevTaskContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
