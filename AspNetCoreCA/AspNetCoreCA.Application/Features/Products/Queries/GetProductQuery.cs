using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Products.Queries
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public int ProductId { get; set; }

        internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            // Correct the parameter names in the constructor
            public GetProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

                if (product == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var productDto = _mapper.Map<ProductDTO>(product);
                return productDto;
            }
        }

    }
}
