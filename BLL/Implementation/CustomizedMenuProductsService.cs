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
    public class CustomizedMenuProductsService : ICustomizedMenuProductsService
    {
        private readonly ICustomizedMenuProductRepository _customizedMenuProductRepository;

        public CustomizedMenuProductsService(ICustomizedMenuProductRepository customizedMenuProductRepository)
        {
            _customizedMenuProductRepository = customizedMenuProductRepository;
        }

        public async Task<IEnumerable<CustomizedMenuProductDTO>> GetAllCustomizedMenuProducts()
        {
            return await _customizedMenuProductRepository.GetAllAsync();
        }
    }
}
