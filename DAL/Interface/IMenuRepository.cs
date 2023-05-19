using DTO;

namespace DAL.Interface
{
    public interface IMenuRepository
    {
        Task<MenuDTO> AddAsync(MenuDTO entity);
        Task<MenuDTO> DeleteAsync(int id);
        Task<IEnumerable<MenuDTO>> GetAllAsync();
        Task<MenuDTO> GetByIdAsync(int id);
        Task<MenuDTO> UpdateAsync(MenuDTO entity);
    }
}