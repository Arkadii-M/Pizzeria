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
    public class OrderStatusRepository : IRepository<OrderStatusDTO>
    {
        private readonly IMapper _mapper;

        public OrderStatusRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderStatusDTO>> GetAllAsync()
        {
            using var context = new PizzeriaContext();
            return await _mapper.ProjectTo <OrderStatusDTO> (context.OrderStatuses).ToListAsync();
        }

        public async Task<OrderStatusDTO> GetByIdAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity =  await context.OrderStatuses.FindAsync(id);
            return _mapper.Map<OrderStatusDTO>(entity);
        }

        public async Task<OrderStatusDTO> AddAsync(OrderStatusDTO entity)
        {
            using var context = new PizzeriaContext();
            var add_entity = _mapper.Map<OrderStatus>(entity);
            await context.OrderStatuses.AddAsync(add_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderStatusDTO>(add_entity);
        }

        public async Task<OrderStatusDTO> UpdateAsync(OrderStatusDTO entity)
        {
            using var context = new PizzeriaContext();
            var update_entity = _mapper.Map<OrderStatus>(entity);
            context.OrderStatuses.Update(update_entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderStatusDTO>(update_entity);
        }

        public async Task<OrderStatusDTO> DeleteAsync(int id)
        {
            using var context = new PizzeriaContext();
            var entity = await context.OrderStatuses.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.OrderStatuses.Remove(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<OrderStatusDTO>(entity);
        }
    }
}
