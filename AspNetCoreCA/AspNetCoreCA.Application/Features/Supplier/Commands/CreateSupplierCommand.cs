using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Supplier.Commands
{
    public class CreateSupplierCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        internal class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
            {
                var supplier = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.Supplier>(request);
                await _unitOfWork.SupplierRepository.AddAsync(supplier);
                _unitOfWork.Save();
                return (int)supplier.Id;
            }
        }
    }
}
