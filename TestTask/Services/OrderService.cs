using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        private const int MinQuantity = 10;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Order> GetOrder()
        {
            var maxQuantityPrice = await _db.Orders.MaxAsync(x => x.Quantity * x.Price);
            var order = await _db.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Quantity * o.Price == maxQuantityPrice);
            return order ?? new Order();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _db.Orders
                .AsNoTracking()
                .Where(o => o.Quantity > MinQuantity)
                .ToListAsync();
        }
    }
}
