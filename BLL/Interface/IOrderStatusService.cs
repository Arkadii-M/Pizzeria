using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrderStatusService
    {
        public Task<IEnumerable<OrderStatusDTO>> GetAllStatuses();
        public Task<OrderStatusDTO> GetOrderStatusByOrderId(int orderId);
    }
}
