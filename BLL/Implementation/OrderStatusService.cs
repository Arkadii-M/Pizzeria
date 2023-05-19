using BLL.Interface;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IOrderRepository orderRepository)
        {
            _orderStatusRepository = orderStatusRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderStatusDTO>> GetAllStatuses()
        {
            return await _orderStatusRepository.GetAllAsync();
        }

        public async Task<OrderStatusDTO> GetOrderStatusByOrderId(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return order.OrderStatus;
        }
    }
}
