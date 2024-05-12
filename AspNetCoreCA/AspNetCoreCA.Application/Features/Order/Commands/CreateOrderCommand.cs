using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Principal;

namespace AspNetCoreCA.Application.Features.Order.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
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

        internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.Order>(request);
                await _unitOfWork.OrderRepository.AddAsync(order);
                _unitOfWork.Save();
                return (int)order.Id;
            }
        }
    }
}
