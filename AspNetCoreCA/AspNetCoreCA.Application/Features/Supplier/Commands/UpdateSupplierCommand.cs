using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Supplier.Commands
{
    public class UpdateSupplierCommand : IRequest<int>
    {
        public int SupplierId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }



        internal class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
            {
                var existingSupplier = await _unitOfWork.SupplierRepository.GetByIdAsync(request.SupplierId);

                if (existingSupplier == null)
                {
                    return 0; // Handle not found scenario
                }

                existingSupplier.FirstName = request.FirstName; // Ensure proper mapping
                existingSupplier.Email = request.Email; // Ensure proper mapping
                existingSupplier.Address = request.Address; // Ensure proper mapping


                await _unitOfWork.SupplierRepository.UpdateAsync(existingSupplier);
                _unitOfWork.Save();

                return (int)existingSupplier.Id;
            }

        }
    }
}
