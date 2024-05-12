using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.OrderDetail.Queries
{
    public class GetOrderDetailQuery : IRequest<OrderDetailDTO>
    {
        public int OrderDetailId { get; set; }

        internal class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetOrderDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<OrderDetailDTO> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(request.OrderDetailId);

                if (orderDetail == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetail);
                return orderDetailDto;
            }
        }
    }
}
