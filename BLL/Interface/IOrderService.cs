using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllOrders();
        public Task<IEnumerable<OrderDTO>> GetUserOrders(string username);
        public Task<IEnumerable<OrderDTO>> GetUserOrders(int userId);
        public Task<OrderDTO> GetOrderById(int orderId);
        public Task<OrderDTO> AddOrder(CustomerOrderDTO order);
        public Task<OrderDTO> ProcessOrder(int orderId);
        public Task<OrderDTO> CancelOrder(int orderId);
    }
}
