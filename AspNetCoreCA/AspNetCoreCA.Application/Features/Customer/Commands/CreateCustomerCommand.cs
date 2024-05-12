using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Customer.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       

        internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.Customer>(request);
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                _unitOfWork.Save();
                return (int)customer.Id;
            }
        }
    }
}
