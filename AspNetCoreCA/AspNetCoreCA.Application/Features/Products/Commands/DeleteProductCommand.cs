using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }

        internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.ProductRepository.DeleteAsync(request.ProductId);
                return Unit.Value;
            }
        }
    }
}
