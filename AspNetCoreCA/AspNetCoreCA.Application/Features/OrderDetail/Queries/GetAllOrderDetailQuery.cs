// Create a new query class for getting all products
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace AspNetCoreCA.Application.Features.OrderDetail.Queries
{
    public class GetAllOrderDetailQuery : IRequest<List<OrderDetailDTO>>
    {
    }

    // Create a query handler for the new query
    internal class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQuery, List<OrderDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrderDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailDTO>> Handle(GetAllOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync();

            // Assuming there is a mapping function to map Product entities to ProductDTO
            var orderDetailsDtos = orderDetails.Select(product => _mapper.Map<OrderDetailDTO>(orderDetails)).ToList();

            return orderDetailsDtos;
        }
    }
}