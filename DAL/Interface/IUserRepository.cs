using DTO;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        Task<UserDTO> AddAsync(UserDTO entity);
        Task<UserDTO> DeleteAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> GetByUserName(string name);
        Task<UserDTO> UpdateAsync(UserDTO entity);
    }
}