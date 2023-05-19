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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderService;

        public OrderService(IOrderRepository orderService, IUserRepository userRepository)
        {
            _orderService = orderService;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            return await _orderService.AddAsync(order);
        }

        public async Task<OrderDTO> CancelOrder(int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
                throw new ArgumentException("No order with that id");
            var state = OrderState.OrderState.GetOrderStateById(order.OrderStatusId ?? throw new Exception("OrderStatusId was null "));
            state = state.CancelOrder();

            order.OrderStatusId = state.CurrentStateId;
            return await _orderService.UpdateAsync(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            return await _orderService.GetAllAsync();
        }

        public async Task<OrderDTO> GetOrderById(int orderId)
        {
            return await _orderService.GetByIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string username)
        {
            var orders = await _orderService.GetAllAsync();
            return orders.Where(o => o.User.UserName == username);
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(int userId)
        {
            var orders = await _orderService.GetAllAsync();
            return orders.Where(o => o.UserId == userId);
        }

        public async Task<OrderDTO> ProcessOrder(int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
                throw new ArgumentException("No order with that id");
            var state = OrderState.OrderState.GetOrderStateById(order.OrderStatusId ?? throw new Exception("OrderStatusId was null "));
            state = state.AssignNextStatus();

            order.OrderStatusId = state.CurrentStateId;
            return await _orderService.UpdateAsync(order);
        }
    }
}
