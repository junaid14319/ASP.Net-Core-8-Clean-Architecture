// UpdateProductCommand.cs
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (existingProduct == null)
            {
                // Handle not found scenario
                return 0; // Return appropriate value for not found
            }

            _mapper.Map(request, existingProduct);

            await _unitOfWork.ProductRepository.UpdateAsync(existingProduct);
            _unitOfWork.Save();  // Use await for asynchronous operations

            return (int)existingProduct.Id;
        }
    }
}
