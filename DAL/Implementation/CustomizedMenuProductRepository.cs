using AutoMapper;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using AutoMapper.QueryableExtensions;

namespace DAL.Implementation
{
    public class CustomizedMenuProductRepository : IRepository<CustomizedMenuProductDTO>
    {
        private readonly IMapper _mapper;

        public CustomizedMenuProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomizedMenuProductDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext();
            return await _mapper.ProjectTo<CustomizedMenuProductDTO>(context.CustomizedMenuProducts).ToListAsync();
        }

        public async Task<CustomizedMenuProductDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.CustomizedMenuProducts.FindAsync(id);
            return _mapper.Map<CustomizedMenuProductDTO>(entity);
        }

        public async Task<CustomizedMenuProductDTO> AddAsync(CustomizedMenuProductDTO entity)
        {
            using var context = new PizzeriaContext();
            var add_entity = _mapper.Map<CustomizedMenuProduct>(entity);
            await context.CustomizedMenuProducts.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomizedMenuProductDTO>(add_entity);
        }

        public async Task<CustomizedMenuProductDTO> UpdateAsync(CustomizedMenuProductDTO entity)
        {
            using var context = new PizzeriaContext();
            var update_entity = _mapper.Map<CustomizedMenuProduct>(entity);
            context.CustomizedMenuProducts.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomizedMenuProductDTO>(update_entity);
        }

        public async Task<CustomizedMenuProductDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.CustomizedMenuProducts.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.CustomizedMenuProducts.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CustomizedMenuProductDTO>(entity);
        }
    }
}
