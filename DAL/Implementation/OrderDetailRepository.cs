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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public OrderDetailRepository(IMapper mapper, string connectionString)
        {
            _mapper = mapper;
            this._connectionString = connectionString;
        }
        public async Task<IEnumerable<OrderDetailDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext(_connectionString);
            return await _mapper.ProjectTo<OrderDetailDTO>(context.OrderDetails).ToListAsync();
        }

        public async Task<OrderDetailDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.OrderDetails.FindAsync(id);
            return _mapper.Map<OrderDetailDTO>(entity);
        }

        public async Task<OrderDetailDTO> AddAsync(OrderDetailDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var add_entity = _mapper.Map<OrderDetail>(entity);
            await context.OrderDetails.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDetailDTO>(add_entity);
        }

        public async Task<OrderDetailDTO> UpdateAsync(OrderDetailDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var update_entity = _mapper.Map<OrderDetail>(entity);
            context.OrderDetails.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDetailDTO>(update_entity);
        }

        public async Task<OrderDetailDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.OrderDetails.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.OrderDetails.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDetailDTO>(entity);
        }
    }
}
