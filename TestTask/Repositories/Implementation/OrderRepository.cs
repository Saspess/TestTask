using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _appContext;

        public OrderRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Order>> GetOrders() =>
            await _appContext.Orders
            .AsNoTracking()
            .Where(o => o.Quantity > 10)
            .ToListAsync();

        public async Task<Order> GetOrder() =>
            await _appContext.Orders
            .AsNoTracking()
            .OrderByDescending(o => o.Price * o.Quantity)
            .FirstOrDefaultAsync();
    }
}
