using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly ECommDbContext _dbContext;

        public CategoryRepository(ECommDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();

            
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
