using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Order.Queries
{
    public class GetOrderQuery : IRequest<OrderDTO>
    {
        public int OrderId { get; set; }

        internal class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);

                if (order == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var orderDto = _mapper.Map<OrderDTO>(order);
                return orderDto;
            }
        }
    }
}
