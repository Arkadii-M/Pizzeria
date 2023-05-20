using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerOrderDTO
    {
        public long UserId { get; set; }
        public DateOnly OrderDate { get; set; }
        public List<MenuDTO> OrderedMenu { get; set; }
    }
}
