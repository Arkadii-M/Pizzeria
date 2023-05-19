using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IMenuService
    {
        public Task<IEnumerable<MenuDTO>> GetAllMenuItems();
    }
}
