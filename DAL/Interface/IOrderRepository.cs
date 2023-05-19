using DTO;

namespace DAL.Interface
{
    public interface IOrderRepository
    {
        Task<OrderDTO> AddAsync(OrderDTO entity);
        Task<OrderDTO> DeleteAsync(int id);
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        Task<OrderDTO> UpdateAsync(OrderDTO entity);
    }
}