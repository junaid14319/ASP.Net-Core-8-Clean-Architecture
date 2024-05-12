using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.OrderDetail.Commands
{
    public class CreateOrderDetailCommand : IRequest<int>
    {
        public int OrderId { get; set; }
       
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    internal class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.OrderDetail>(request);
            await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
            _unitOfWork.Save();  // Use await for asynchronous operations
            return (int)orderDetail.Id;
        }
    }
}