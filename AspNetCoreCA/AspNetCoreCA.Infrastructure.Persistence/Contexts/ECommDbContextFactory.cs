using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Infrastructure.Persistence.Contexts
{
    public class ECommDbContextFactory : IDesignTimeDbContextFactory<ECommDbContext>
    {
        public ECommDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ECommDbContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new ECommDbContext(optionsBuilder.Options);
        }
    }

}
