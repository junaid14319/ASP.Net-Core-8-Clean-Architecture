using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.PaymentDetail.Commands
{
    public class DeletePaymentDetailCommand : IRequest<Unit>
    {
        public int PaymentId { get; set; }

        internal class DeletePaymentDetailCommandHandler : IRequestHandler<DeletePaymentDetailCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeletePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeletePaymentDetailCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.PaymentDetailRepository.DeleteAsync(request.PaymentId);
                return Unit.Value;
            }
        }
    }
}
