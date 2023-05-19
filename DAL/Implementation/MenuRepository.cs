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

    public class MenuRepository : IMenuRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public MenuRepository(IMapper mapper, string connectionString)
        {
            _mapper = mapper;
            this._connectionString = connectionString;
        }
        public async Task<IEnumerable<MenuDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext(_connectionString);
            return await _mapper.ProjectTo<MenuDTO>(context.Menus).ToListAsync();
        }

        public async Task<MenuDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.Menus.FindAsync(id);
            return _mapper.Map<MenuDTO>(entity);
        }

        public async Task<MenuDTO> AddAsync(MenuDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var add_entity = _mapper.Map<Menu>(entity);
            await context.Menus.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<MenuDTO>(add_entity);
        }

        public async Task<MenuDTO> UpdateAsync(MenuDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var update_entity = _mapper.Map<Menu>(entity);
            context.Menus.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<MenuDTO>(update_entity);
        }

        public async Task<MenuDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.Menus.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.Menus.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<MenuDTO>(entity);
        }
    }
}
