using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IRoleService
    {
        public Task<RoleDTO> GetUserRole(string username);
        public Task<RoleDTO> GetUserRole(int userId);
        public Task<IEnumerable<RoleDTO>> GetRoles();
    }
}
