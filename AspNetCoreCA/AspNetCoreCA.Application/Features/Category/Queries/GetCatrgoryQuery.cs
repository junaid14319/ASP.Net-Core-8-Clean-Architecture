using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Category.Queries
{
    public class GetCategoryQuery : IRequest<CategoryDTO>
    {
        public int Id { get; set; }

        internal class GetCatrgoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCatrgoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

                if (category == null)
                {
                    // Handle not found scenario
                    return null;
                }

                var categoryDto = _mapper.Map<CategoryDTO>(category);
                return categoryDto;
            }
        }
    }
}
