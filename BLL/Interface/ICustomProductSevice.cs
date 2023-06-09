﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICustomProductSevice
    {
        public Task<IEnumerable<CustomProductDTO>> GetAllCustomProducts();
        public Task<IEnumerable<CustomProductDTO>> GetPizzaCustomProducts();
        public Task<IEnumerable<CustomProductDTO>> GetSaladCustomProducts();
    }
}
