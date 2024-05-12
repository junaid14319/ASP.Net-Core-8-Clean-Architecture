// UpdateProductCommand.cs
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.PaymentDetail.Commands
{
    public class UpdatePaymentDetailCommand : IRequest<int>
    {
        public int paymentId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    internal class UpdatePaymentDetailCommandHandler : IRequestHandler<UpdatePaymentDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var existingPayment = await _unitOfWork.PaymentDetailRepository.GetByIdAsync(request.paymentId);

            if (existingPayment == null)
            {
                // Handle not found scenario
                return 0; // Return appropriate value for not found
            }

            _mapper.Map(request, existingPayment);

            await _unitOfWork.PaymentDetailRepository.UpdateAsync(existingPayment);
            _unitOfWork.Save();  // Use await for asynchronous operations

            return (int)existingPayment.Id;
        }
    }
}
