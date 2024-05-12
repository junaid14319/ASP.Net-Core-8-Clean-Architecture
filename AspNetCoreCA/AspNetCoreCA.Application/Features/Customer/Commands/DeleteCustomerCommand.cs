using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Customer.Commands
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int CustomerId { get; set; }

        internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.CustomerRepository.DeleteAsync(request.CustomerId);
                _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}
