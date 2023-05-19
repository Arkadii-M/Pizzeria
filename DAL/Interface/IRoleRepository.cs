using DTO;

namespace DAL.Interface
{
    public interface IRoleRepository
    {
        Task<RoleDTO> AddAsync(RoleDTO entity);
        Task<RoleDTO> DeleteAsync(int id);
        Task<IEnumerable<RoleDTO>> GetAllAsync();
        Task<RoleDTO> GetByIdAsync(int id);
        Task<RoleDTO> UpdateAsync(RoleDTO entity);
    }
}