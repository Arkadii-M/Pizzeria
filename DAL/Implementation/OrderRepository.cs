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
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public OrderRepository(IMapper mapper, string connectionString)
        {
            _mapper = mapper;
            this._connectionString = connectionString;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext(_connectionString);
            return await _mapper.ProjectTo<OrderDTO>(context.Orders).ToListAsync();
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            //var entity = await context.Orders
            //    .Include(o => o.OrderStatus)
            //    .Include(o => o.OrderDetails).FirstOrDefaultAsync(f => f.OrderId == id);
            var entity = await context.Orders.Include(o => o.OrderStatus).FirstOrDefaultAsync(f => f.OrderId == id);
            return _mapper.Map<OrderDTO>(entity);
        }

        public async Task<OrderDTO> AddAsync(OrderDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var add_entity = _mapper.Map<Order>(entity);
            await context.Orders.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(add_entity);
        }

        public async Task<OrderDTO> UpdateAsync(OrderDTO entity)
        {
            using var context = new PizzeriaContext(_connectionString);
            var update_entity = _mapper.Map<Order>(entity);
            context.Orders.Update(update_entity);
            await context.SaveChangesAsync();
            return await GetByIdAsync(entity.OrderId);
        }

        public async Task<OrderDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext(_connectionString);
            var entity = await context.Orders.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.Orders.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(entity);
        }
    }
}
