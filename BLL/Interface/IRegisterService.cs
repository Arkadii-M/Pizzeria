using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IRegisterService
    {
        public Task<UserDTO> RegisterUser(string username, string email, string password);
    }
}
