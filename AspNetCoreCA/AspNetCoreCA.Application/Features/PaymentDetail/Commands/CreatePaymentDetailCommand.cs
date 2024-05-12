using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.PaymentDetail.Commands
{
    public class CreatePaymentDetailCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    internal class CreatePaymentDetailCommandHandler : IRequestHandler<CreatePaymentDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.PaymentDetail>(request);
            await _unitOfWork.PaymentDetailRepository.AddAsync(payment);
            _unitOfWork.Save();  // Use await for asynchronous operations
            return (int)payment.Id;
        }
    }
}