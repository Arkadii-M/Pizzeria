using DTO;

namespace DAL.Interface
{
    public interface IUserStatusRepository
    {
        Task<UserStatusDTO> AddAsync(UserStatusDTO entity);
        Task<UserStatusDTO> DeleteAsync(int id);
        Task<IEnumerable<UserStatusDTO>> GetAllAsync();
        Task<UserStatusDTO> GetByIdAsync(int id);
        Task<UserStatusDTO> UpdateAsync(UserStatusDTO entity);
    }
}