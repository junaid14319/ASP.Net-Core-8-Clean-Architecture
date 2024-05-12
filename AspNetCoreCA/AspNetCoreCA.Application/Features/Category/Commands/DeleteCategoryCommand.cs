using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int CategoryId { get; set; }

        internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(request.CategoryId);
                _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}
