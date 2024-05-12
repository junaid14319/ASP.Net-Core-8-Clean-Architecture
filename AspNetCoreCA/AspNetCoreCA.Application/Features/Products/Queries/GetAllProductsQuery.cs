// Create a new query class for getting all products
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Application.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace AspNetCoreCA.Application.Features.Products.Queries
{ 
public class GetAllProductQuery : IRequest<List<ProductDTO>>
{
}

// Create a query handler for the new query
internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();

        // Assuming there is a mapping function to map Product entities to ProductDTO
        var productDtos = products.Select(product => _mapper.Map<ProductDTO>(product)).ToList();

        return productDtos;
    }
}
}