using PublishingHouse.Constats;
using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishingHouse.Services
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ChangeOrderStatusAsync(int orderId, OrderStatus status)
        {
            OrderRepository orderRepository = _unitOfWork.OrderRepository;

            Order order = orderRepository.GetById(orderId);

            order.Status = status.ToString();

            orderRepository.Update(order);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateOrderAsync(CreateOrderDTO createOrderDTO)
        {
            OrderRepository orderRepository = _unitOfWork.OrderRepository;

            Order newOrder = new Order()
            {
                User = createOrderDTO.User,
                OrderDate = createOrderDTO.OrderDate,
                PrintedEditions = createOrderDTO.PrintedEditions.ToList(),
                TotalPrice = createOrderDTO.PrintedEditions.Sum(p => p.Price),
                Status = OrderStatus.NotPaid.ToString()
            };

            await orderRepository.AddAsync(newOrder);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            OrderRepository orderRepository = _unitOfWork.OrderRepository;

            return orderRepository.GetByUserId(userId);
        }
    }
}
