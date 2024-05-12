using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Repositories
{
    public class OrderDetailRepository : IGenericRepository<OrderDetail>
    {
        private readonly ECommDbContext _dbContext;

        public OrderDetailRepository(ECommDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<OrderDetail>> GetAllAsync()
        {
            return await _dbContext.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await _dbContext.OrderDetails.FindAsync(id);
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _dbContext.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
