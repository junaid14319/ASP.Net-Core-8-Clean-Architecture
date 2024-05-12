// Create a new query class for getting all categories
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace AspNetCoreCA.Application.Features.Order.Queries;

public class GetAllOrderQuery : IRequest<List<OrderDTO>>
{
}

// Create a query handler for the new query
internal class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<OrderDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync();

        // Assuming there is a mapping function to map Category entities to CategoryDTO
        var orderDtos = orders.Select(category => _mapper.Map<OrderDTO>(orders)).ToList();

        return orderDtos;
    }
}
