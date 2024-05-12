using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Customer.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var existingCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);

                if (existingCustomer == null)
                {
                    return 0; // Handle not found scenario
                }

             //   existingCategory.Name = request.Name; // Ensure proper mapping

                await _unitOfWork.CustomerRepository.UpdateAsync(existingCustomer);
                _unitOfWork.Save();

                return (int)existingCustomer.Id;
            }

        }
    }
}
