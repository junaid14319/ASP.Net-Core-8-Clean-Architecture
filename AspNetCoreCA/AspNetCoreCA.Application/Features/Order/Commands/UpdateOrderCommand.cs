using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Order.Commands
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HomeAddress { get; set; }
        //public string? OrderStatus { get; set; }
        //public string? PaymentStatus { get; set; }
        //public string? TrackingNumbre { get; set; }
        //public string? Carrier { get; set; }
        //public string? SessionId { get; set; } 
        public string? PaymentIntenId { get; set; }


        internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var existingOrder = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);

                if (existingOrder == null)
                {
                    return 0; // Handle not found scenario
                }

               
                

                await _unitOfWork.OrderRepository.UpdateAsync(existingOrder);
                _unitOfWork.Save();

                return (int)existingOrder.Id;
            }

        }
    }
}
