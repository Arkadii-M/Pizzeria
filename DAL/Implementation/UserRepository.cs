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
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public UserRepository(IMapper mapper, string connectionString)
        {
            _mapper = mapper;
            this._connectionString = connectionString;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            using var e = new PizzeriaContext(_connectionString);
            return await _mapper.ProjectTo<UserDTO>(e.Users).ToListAsync();
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            using var e = new PizzeriaContext(_connectionString);
            var entity = await e.Users.FindAsync(id);
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<UserDTO> AddAsync(UserDTO entity)
        {
            using var e = new PizzeriaContext(_connectionString);
            var add_entity = _mapper.Map<User>(entity);
            await e.Users.AddAsync(add_entity);
            await e.SaveChangesAsync();
            return _mapper.Map<UserDTO>(add_entity);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO entity)
        {
            using var e = new PizzeriaContext(_connectionString);
            var update_entity = _mapper.Map<User>(entity);
            e.Users.Update(update_entity);
            await e.SaveChangesAsync();
            return _mapper.Map<UserDTO>(update_entity);
        }

        public async Task<UserDTO> DeleteAsync(int id)
        {
            using var e = new PizzeriaContext(_connectionString);
            var entity = await e.Users.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            e.Users.Remove(entity);
            await e.SaveChangesAsync();
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<UserDTO> GetByUserName(string username)
        {
            using var e = new PizzeriaContext(_connectionString);
            var entity = await e.Users.Where(u => u.UserName == username).Include(u => u.Role).FirstOrDefaultAsync();
            return _mapper.Map<UserDTO>(entity);
        }
    }
}
