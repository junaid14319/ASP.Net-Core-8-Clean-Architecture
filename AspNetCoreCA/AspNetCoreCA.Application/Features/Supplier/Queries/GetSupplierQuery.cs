using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Supplier.Queries
{
    public class GetSupplierQuery : IRequest<SupplierDTO>
    {
        public int SupplierId { get; set; }

        internal class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, SupplierDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetSupplierQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<SupplierDTO> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
            {
                var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(request.SupplierId);

                if (supplier == null)
                {
                 
                  // Handle not found scenario
                    return null;
                }

                var supplierDto = _mapper.Map<SupplierDTO>(supplier);
                return supplierDto;
            }
        }
    }
}
