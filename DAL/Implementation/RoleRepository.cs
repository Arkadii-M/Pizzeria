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
    public class RoleRepository : IRepository<RoleDTO>
    {

        private readonly IMapper _mapper;

        public RoleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllAsync()
        {
            using var e = new PizzeriaContext();
            return await _mapper.ProjectTo<RoleDTO>(e.Roles).ToListAsync();
        }

        public async Task<RoleDTO> GetByIdAsync(int id)
        {
            using var e = new PizzeriaContext();
            var entity =  await e.Roles.FindAsync(id);
            return _mapper.Map<RoleDTO>(entity);
        }

        public async Task<RoleDTO> AddAsync(RoleDTO entity)
        {
            using var e = new PizzeriaContext();
            var add_entity = _mapper.Map<Role>(entity);
            await e.Roles.AddAsync(add_entity);
            await e.SaveChangesAsync();
            return _mapper.Map<RoleDTO>(add_entity);
        }

        public async Task<RoleDTO> UpdateAsync(RoleDTO entity)
        {
            using var e = new PizzeriaContext();
            var update_entity = _mapper.Map<Role>(entity);
            e.Roles.Update(update_entity);
            await e.SaveChangesAsync();
            return _mapper.Map<RoleDTO>(update_entity);
        }

        public async Task<RoleDTO> DeleteAsync(int id)
        {
            using var e = new PizzeriaContext();
            var entity = await e.Roles.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            e.Roles.Remove(entity);
            await e.SaveChangesAsync();
            return _mapper.Map<RoleDTO>(entity);
        }
    }
}
