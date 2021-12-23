using InnovationDevTask.Core.IRepositories;

namespace InnovationDevTask.Core
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }

        int Complete();
    }
}
