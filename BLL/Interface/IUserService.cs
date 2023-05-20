using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(int id);
        public Task<UserDTO> GetByUserName(string username);
    }
}
