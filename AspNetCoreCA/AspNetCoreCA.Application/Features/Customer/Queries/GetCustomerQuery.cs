using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Customer.Queries
{
    public class GetCustomerQuery : IRequest<CustomerDTO>
    {
        public int CustomerId { get; set; }

        internal class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);

                if (customer == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var customerDto = _mapper.Map<CustomerDTO>(customer);
                return customerDto;
            }
        }
    }
}
