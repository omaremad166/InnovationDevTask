using InnovationDevTask.Core.IRepositories;
using InnovationDevTask.Data;

namespace InnovationDevTask.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InnovationDevTaskContext _context;
        public IOrderRepository Orders { get; }
        public UnitOfWork(InnovationDevTaskContext context, IOrderRepository orders)
        {
            _context = context;
            Orders = orders;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
