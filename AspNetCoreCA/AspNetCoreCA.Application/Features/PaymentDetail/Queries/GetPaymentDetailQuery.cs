using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.PaymentDetail.Queries
{
    public class GetPaymentDetailQuery : IRequest<PaymentDetailDTO>
    {
        public int PaymentDetailId { get; set; }

        internal class GetPaymentDetailQueryHandler : IRequestHandler<GetPaymentDetailQuery, PaymentDetailDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetPaymentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<PaymentDetailDTO> Handle(GetPaymentDetailQuery request, CancellationToken cancellationToken)
            {
                var paymentDetail = await _unitOfWork.PaymentDetailRepository.GetByIdAsync(request.PaymentDetailId);

                if (paymentDetail == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var paymentDto = _mapper.Map<PaymentDetailDTO>(paymentDetail);
                return paymentDto;
            }
        }
    }
}
