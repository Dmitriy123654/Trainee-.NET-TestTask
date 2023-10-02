using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrder();

        public Task<List<Order>> GetOrders();
    }
}
