using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Repositories
{
    public class PaymentDetailRepository : IGenericRepository<PaymentDetail>
    {
        private readonly ECommDbContext _dbContext;

        public PaymentDetailRepository(ECommDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<PaymentDetail>> GetAllAsync()
        {
            return await _dbContext.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> GetByIdAsync(int id)
        {
            return await _dbContext.PaymentDetails.FindAsync(id);
        }

        public async Task AddAsync(PaymentDetail paymentDetail)
        {
            _dbContext.PaymentDetails.Add(paymentDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaymentDetail paymentDetail)
        {
            _dbContext.Entry(paymentDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paymentDetail = await _dbContext.PaymentDetails.FindAsync(id);
            if (paymentDetail != null)
            {
                _dbContext.PaymentDetails.Remove(paymentDetail);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
