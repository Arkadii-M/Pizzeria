using DTO;

namespace DAL.Interface
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetailDTO> AddAsync(OrderDetailDTO entity);
        Task<OrderDetailDTO> DeleteAsync(int id);
        Task<IEnumerable<OrderDetailDTO>> GetAllAsync();
        Task<OrderDetailDTO> GetByIdAsync(int id);
        Task<OrderDetailDTO> UpdateAsync(OrderDetailDTO entity);
    }
}