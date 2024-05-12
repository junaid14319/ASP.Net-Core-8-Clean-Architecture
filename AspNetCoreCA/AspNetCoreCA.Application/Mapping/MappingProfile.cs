using AutoMapper;
using AspNetCoreCA.Application.Features.Supplier.Commands;
using AspNetCoreCA.Domain.ModelEntity;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Application.Features.Customer.Commands;
using AspNetCoreCA.Application.Features.Customer.Queries;
using AspNetCoreCA.Application.Features.Customer.Query;
using AspNetCoreCA.Application.Features.Order.Commands;
using AspNetCoreCA.Application.Features.Order.Queries;
using AspNetCoreCA.Application.Features.Order.Queries;
using AspNetCoreCA.Application.Features.Category.Commands;
using AspNetCoreCA.Application.Features.Category.Queries;
using AspNetCoreCA.Application.Features.OrderDetail.Commands;
using AspNetCoreCA.Application.Features.OrderDetail.Queries;
using AspNetCoreCA.Application.Features.PaymentDetail.Commands;
using AspNetCoreCA.Application.Features.Supplier.Queries;
using AspNetCoreCA.Application.Features.PaymentDetail.Queries;
using AspNetCoreCA.Application.Features.PaymentDetail.Query;
using AspNetCoreCA.Application.Features.Products.Commands;
using AspNetCoreCA.Application.Features.Products.Queries;


namespace AspNetCoreCA.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<PaymentDetail, PaymentDetailDTO>().ReverseMap();
                               
            //===================this Category=====================
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategroyCommand, Category>().ReverseMap();
            CreateMap<DeleteCategoryCommand, Category>().ReverseMap();
            CreateMap<GetCategoryQuery, Category>().ReverseMap();
            CreateMap<GetAllCategoryQuery, Category>().ReverseMap();
            //==================For Products========================
            CreateMap<CreateProductCommand, Product >().ReverseMap();
            CreateMap<UpdateProductCommand, Product >().ReverseMap();
            CreateMap<DeleteProductCommand, Product >().ReverseMap();
            CreateMap<GetProductQuery, Product >().ReverseMap();
            CreateMap<GetAllProductQuery, Product>().ReverseMap();
            //==================For Supllier========================
            CreateMap<CreateSupplierCommand, Supplier>().ReverseMap();
            CreateMap<UpdateSupplierCommand, Supplier>().ReverseMap();
            CreateMap<DeleteSupplierCommand, Supplier>().ReverseMap();
            CreateMap<GetSupplierQuery, Supplier>().ReverseMap();
            CreateMap<GetAllSupplierQuery, Supplier>().ReverseMap();
            //==================For Customer========================
            CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap();
            CreateMap<DeleteCustomerCommand, Customer>().ReverseMap();
            CreateMap<GetCustomerQuery, Customer>().ReverseMap();
            CreateMap<GetAllCustomerQuery, Customer>().ReverseMap();
            //==================For Order========================
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<DeleteOrderCommand, Order>().ReverseMap();
            CreateMap<GetOrderQuery, Order>().ReverseMap();
            CreateMap<GetAllOrderQuery, Order>().ReverseMap();
            //==================For OrderDetial========================
            CreateMap<CreateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<DeleteOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<GetOrderDetailQuery, OrderDetail>().ReverseMap();
            CreateMap<GetAllOrderDetailQuery, OrderDetail>().ReverseMap();
            //==================For PaymentDetail========================
            CreateMap<CreatePaymentDetailCommand, PaymentDetail>().ReverseMap();
            CreateMap<UpdatePaymentDetailCommand, PaymentDetail>().ReverseMap();
            CreateMap<DeletePaymentDetailCommand, PaymentDetail>().ReverseMap();
            CreateMap<GetPaymentDetailQuery,  PaymentDetail>().ReverseMap();
            CreateMap<GetAllPaymentDetailQuery, PaymentDetail>().ReverseMap();
            //==================For Login And Singup ========================
           // CreateMap<CreateUserCommand, User>().ReverseMap();
            //CreateMap<UpdateUserCommand, User>().ReverseMap();
            //CreateMap<DeleteUserCommand, User>().ReverseMap();
            //CreateMap<GetUserQuery, User>().ReverseMap();
           // CreateMap<GetAllUserQuery,User>().ReverseMap();


        }
    }
}
