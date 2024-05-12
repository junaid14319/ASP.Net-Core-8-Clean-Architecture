using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        
        internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<AspNetCoreCA.Domain.ModelEntity.Category>(request);
                await _unitOfWork.CategoryRepository.AddAsync(category);
                _unitOfWork.Save();
                return (int)category.Id;
            }
        }
    }
}
