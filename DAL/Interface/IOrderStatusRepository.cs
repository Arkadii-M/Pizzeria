using DTO;

namespace DAL.Interface
{
    public interface IOrderStatusRepository
    {
        Task<OrderStatusDTO> AddAsync(OrderStatusDTO entity);
        Task<OrderStatusDTO> DeleteAsync(int id);
        Task<IEnumerable<OrderStatusDTO>> GetAllAsync();
        Task<OrderStatusDTO> GetByIdAsync(int id);
        Task<OrderStatusDTO> UpdateAsync(OrderStatusDTO entity);
    }
}