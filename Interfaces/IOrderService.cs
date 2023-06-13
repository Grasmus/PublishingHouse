using PublishingHouse.Constats;
using PublishingHouse.DTOs;
using PublishingHouse.Models.OrderEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublishingHouse.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDTO createOrderDTO);
        List<Order> GetOrdersByUserId(int userId);
        Task ChangeOrderStatusAsync(int orderId, OrderStatus status);
    }
}
