using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrder();

        public Task<List<Order>> GetOrders();
    }
}
