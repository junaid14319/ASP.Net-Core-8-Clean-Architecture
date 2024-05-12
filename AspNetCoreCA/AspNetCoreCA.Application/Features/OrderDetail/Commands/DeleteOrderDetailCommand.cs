using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.OrderDetail.Commands
{
    public class DeleteOrderDetailCommand : IRequest<Unit>
    {
        public int OrderDetailId { get; set; }

        internal class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteOrderDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.OrderDetailRepository.DeleteAsync(request.OrderDetailId);
                return Unit.Value;
            }
        }
    }
}
