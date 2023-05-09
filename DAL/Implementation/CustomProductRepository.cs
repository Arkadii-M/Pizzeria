using AutoMapper;
using DAL.Interface;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class CustomProductRepository : IRepository<CustomProductDTO>
    {
        private readonly IMapper _mapper;

        public CustomProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomProductDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext();
            return await _mapper.ProjectTo<CustomProductDTO>(context.CustomProducts).ToListAsync();
        }

        public async Task<CustomProductDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.CustomProducts.FindAsync(id);
            return _mapper.Map<CustomProductDTO>(entity);
        }

        public async Task<CustomProductDTO> AddAsync(CustomProductDTO entity)
        {
            using var context = new PizzeriaContext();
            var add_entity = _mapper.Map<CustomProduct>(entity);
            await context.CustomProducts.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomProductDTO>(add_entity);
        }

        public async Task<CustomProductDTO> UpdateAsync(CustomProductDTO entity)
        {
            using var context = new PizzeriaContext();
            var update_entity = _mapper.Map<CustomProduct>(entity);
            context.CustomProducts.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomProductDTO>(update_entity);
        }

        public async Task<CustomProductDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.CustomProducts.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.CustomProducts.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomProductDTO>(entity);
        }
    }
}
