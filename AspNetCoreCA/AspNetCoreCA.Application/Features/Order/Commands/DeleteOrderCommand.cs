using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Order.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int OrderId { get; set; }

        internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.OrderRepository.DeleteAsync(request.OrderId);
                _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}
