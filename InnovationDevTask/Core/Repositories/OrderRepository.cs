using InnovationDevTask.Core.IRepositories;
using InnovationDevTask.Data;
using InnovationDevTask.Models;

namespace InnovationDevTask.Core.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(InnovationDevTaskContext context) : base (context) { }
    }
}
