using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Repositories
{
    public class SuplierRepository : IGenericRepository<Supplier>
    {
        private readonly ECommDbContext _dbContext;

        public SuplierRepository(ECommDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Supplier>> GetAllAsync()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task AddAsync(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
