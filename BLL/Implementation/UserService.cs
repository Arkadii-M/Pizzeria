using BLL.Interface;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserDTO> GetByUserName(string username)
        {
            return await _userRepository.GetByUserName(username);
        }
    }
}
