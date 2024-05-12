using AutoMapper;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreCA.Application.IRepositories;

namespace AspNetCoreCA.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = _mapper.Map<Product>(request);
            await _unitOfWork.ProductRepository.AddAsync(product);
            _unitOfWork.Save();  
            return (int)product.Id;
        }
    }
}