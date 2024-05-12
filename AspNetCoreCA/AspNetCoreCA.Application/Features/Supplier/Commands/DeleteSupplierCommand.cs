using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Supplier.Commands
{
    public class DeleteSupplierCommand : IRequest<Unit>
    {
        public int SupplierId { get; set; }

        internal class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(request.SupplierId);
                _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}
