using DTO;

namespace DAL.Interface
{
    public interface ICustomizedMenuProductRepository
    {
        Task<CustomizedMenuProductDTO> AddAsync(CustomizedMenuProductDTO entity);
        Task<CustomizedMenuProductDTO> DeleteAsync(int id);
        Task<IEnumerable<CustomizedMenuProductDTO>> GetAllAsync();
        Task<CustomizedMenuProductDTO> GetByIdAsync(int id);
        Task<CustomizedMenuProductDTO> UpdateAsync(CustomizedMenuProductDTO entity);
    }
}