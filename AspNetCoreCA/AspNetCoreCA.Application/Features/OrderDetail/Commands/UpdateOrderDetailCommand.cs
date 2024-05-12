// UpdateProductCommand.cs
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.OrderDetail.Commands
{
    public class UpdateOrderDetailCommand : IRequest<int>
    {
        public int OrderDetailId { get; set; }
 
    }

    internal class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var existingOrderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(request.OrderDetailId);

            if (existingOrderDetail == null)
            {
                // Handle not found scenario
                return 0; // Return appropriate value for not found
            }

            _mapper.Map(request, existingOrderDetail);

            await _unitOfWork.OrderDetailRepository.UpdateAsync(existingOrderDetail);
            _unitOfWork.Save();  // Use await for asynchronous operations

            return existingOrderDetail.OrderId;
        }
    }
}
