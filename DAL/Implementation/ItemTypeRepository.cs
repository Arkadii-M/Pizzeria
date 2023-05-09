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
    public class ItemTypeRepository : IRepository<ItemTypeDTO>
    {
        private readonly IMapper _mapper;

        public ItemTypeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemTypeDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext();
            return await _mapper.ProjectTo<ItemTypeDTO>(context.ItemTypes).ToListAsync();
        }

        public async Task<ItemTypeDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity =  await context.ItemTypes.FindAsync(id);
            return _mapper.Map<ItemTypeDTO>(entity);
        }

        public async Task<ItemTypeDTO> AddAsync(ItemTypeDTO entity)
        {
            using var context = new PizzeriaContext();
            var add_entity = _mapper.Map<ItemType>(entity);
            await context.ItemTypes.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<ItemTypeDTO>(add_entity);
        }

        public async Task<ItemTypeDTO> UpdateAsync(ItemTypeDTO entity)
        {
            using var context = new PizzeriaContext();
            var update_entity = _mapper.Map<ItemType>(entity);
            context.ItemTypes.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<ItemTypeDTO>(update_entity);
        }

        public async Task<ItemTypeDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.ItemTypes.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.ItemTypes.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<ItemTypeDTO>(entity);
        }
    }
}
