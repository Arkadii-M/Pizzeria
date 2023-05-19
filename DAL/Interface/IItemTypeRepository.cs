using DTO;

namespace DAL.Interface
{
    public interface IItemTypeRepository
    {
        Task<ItemTypeDTO> AddAsync(ItemTypeDTO entity);
        Task<ItemTypeDTO> DeleteAsync(int id);
        Task<IEnumerable<ItemTypeDTO>> GetAllAsync();
        Task<ItemTypeDTO> GetByIdAsync(int id);
        Task<ItemTypeDTO> UpdateAsync(ItemTypeDTO entity);
    }
}