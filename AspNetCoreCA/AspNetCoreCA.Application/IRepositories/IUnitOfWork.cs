using AspNetCoreCA.Domain.ModelEntity;
using System;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<PaymentDetail> PaymentDetailRepository { get; }
        IGenericRepository<Customer> CustomerRepository { get; }
        IGenericRepository<Supplier> SupplierRepository { get; }
        
    
        public void Save();
       
    }
}
