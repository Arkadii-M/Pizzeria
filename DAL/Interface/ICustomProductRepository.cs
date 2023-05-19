using DTO;

namespace DAL.Interface
{
    public interface ICustomProductRepository
    {
        Task<CustomProductDTO> AddAsync(CustomProductDTO entity);
        Task<CustomProductDTO> DeleteAsync(int id);
        Task<IEnumerable<CustomProductDTO>> GetAllAsync();
        Task<CustomProductDTO> GetByIdAsync(int id);
        Task<CustomProductDTO> UpdateAsync(CustomProductDTO entity);
    }
}