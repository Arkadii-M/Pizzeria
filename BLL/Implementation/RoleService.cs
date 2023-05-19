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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<RoleDTO> GetUserRole(string username)
        {
            var user = await _userRepository.GetByUserName(username);
            if (user == null)
                throw new Exception("No user with given username found");

            return user.Role;
        }

        public async Task<RoleDTO> GetUserRole(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("No user with given id found");

            return user.Role;
        }
    }
}
