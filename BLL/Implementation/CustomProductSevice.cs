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
    public class CustomProductSevice : ICustomProductSevice
    {
        private readonly ICustomProductRepository _customProductRepository;

        public CustomProductSevice(ICustomProductRepository customProductRepository)
        {
            _customProductRepository = customProductRepository;
        }

        public async Task<IEnumerable<CustomProductDTO>> GetAllCustomProducts()
        {
            return await _customProductRepository.GetAllAsync();
        }
    }
}
