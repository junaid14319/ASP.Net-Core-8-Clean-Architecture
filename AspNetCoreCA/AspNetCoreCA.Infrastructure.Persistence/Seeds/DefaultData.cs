using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Seeds
{
    public static class DefaultData
    {
        public static async Task SeedAsync(ECommDbContext applicationDbContext)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "SqlSeedData");

            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    var command = File.ReadAllText(item);
                    try
                    {
                        await applicationDbContext.Database.ExecuteSqlRawAsync(command);
                    }
                    catch
                    {
                    }
                }

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
