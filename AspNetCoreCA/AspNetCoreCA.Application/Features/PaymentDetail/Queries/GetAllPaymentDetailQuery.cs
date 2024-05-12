// Create a new query class for getting all products
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace AspNetCoreCA.Application.Features.PaymentDetail.Query
{
    public class GetAllPaymentDetailQuery : IRequest<List<PaymentDetailDTO>>
    {
    }

    // Create a query handler for the new query
    internal class GetAllPaymentDetailQueryHandler : IRequestHandler<GetAllPaymentDetailQuery, List<PaymentDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPaymentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PaymentDetailDTO>> Handle(GetAllPaymentDetailQuery request, CancellationToken cancellationToken)
        {
            var paymentDetails = await _unitOfWork.PaymentDetailRepository.GetAllAsync();

            // Assuming there is a mapping function to map Product entities to paymentDTO
            var paymentDetailsDto = paymentDetails.Select(payment => _mapper.Map<PaymentDetailDTO>(payment)).ToList();

            return paymentDetailsDto;
        }
    }
}