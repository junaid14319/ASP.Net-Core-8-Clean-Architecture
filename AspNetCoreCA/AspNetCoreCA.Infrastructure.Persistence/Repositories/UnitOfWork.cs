using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;

namespace AspNetCoreCA.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommDbContext _dbContext;

        public UnitOfWork(ECommDbContext dbContext)
        {
            _dbContext = dbContext;
            ProductRepository = new GenericRepository<Product>(_dbContext);
            CategoryRepository = new GenericRepository<Category>(_dbContext);
            OrderRepository = new GenericRepository<Order>(_dbContext);
            OrderDetailRepository = new GenericRepository<OrderDetail>(_dbContext);
            PaymentDetailRepository = new GenericRepository<PaymentDetail>(_dbContext);
            CustomerRepository = new GenericRepository<Customer>(_dbContext);
            SupplierRepository = new GenericRepository<Supplier>(_dbContext);
           
        }

        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Order> OrderRepository { get; }
        public IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        public IGenericRepository<PaymentDetail> PaymentDetailRepository { get; }
        public IGenericRepository<Customer> CustomerRepository { get; }
        public IGenericRepository<Supplier> SupplierRepository { get; }
        
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
