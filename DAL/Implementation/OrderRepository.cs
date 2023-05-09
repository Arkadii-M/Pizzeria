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
    public class OrderRepository : IRepository<OrderDTO>
 
    {
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext();
            return await _mapper.ProjectTo<OrderDTO>(context.Orders).ToListAsync();
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.Orders.FindAsync(id);
            return _mapper.Map<OrderDTO>(entity);
        }

        public async Task<OrderDTO> AddAsync(OrderDTO entity)
        {
            using var context = new PizzeriaContext();
            var add_entity = _mapper.Map<Order>(entity);
            await context.Orders.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(add_entity);
        }

        public async Task<OrderDTO> UpdateAsync(OrderDTO entity)
        {
            using var context = new PizzeriaContext();
            var update_entity = _mapper.Map<Order>(entity);
            context.Orders.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(update_entity);
        }

        public async Task<OrderDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext();
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
