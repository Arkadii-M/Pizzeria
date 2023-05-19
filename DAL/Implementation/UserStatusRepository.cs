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
    public class UserStatusRepository : IUserStatusRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public UserStatusRepository(IMapper mapper, string connectionString)
        {
            _mapper = mapper;
            this._connectionString = connectionString;
        }
        public async Task<IEnumerable<UserStatusDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext(_connectionString);
            return await _mapper.ProjectTo<UserStatusDTO>(context.UserStatuses).ToListAsync();
        }

        public async Task<UserStatusDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.UserStatuses.FindAsync(id);
            return _mapper.Map<UserStatusDTO>(entity);
        }

        public async Task<UserStatusDTO> AddAsync(UserStatusDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var add_entity = _mapper.Map<UserStatus>(entity);
            await context.UserStatuses.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<UserStatusDTO>(add_entity);
        }

        public async Task<UserStatusDTO> UpdateAsync(UserStatusDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var update_entity = _mapper.Map<UserStatus>(entity);
            context.UserStatuses.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<UserStatusDTO>(update_entity);
        }

        public async Task<UserStatusDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.UserStatuses.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.UserStatuses.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<UserStatusDTO>(entity);
        }
    }
}
