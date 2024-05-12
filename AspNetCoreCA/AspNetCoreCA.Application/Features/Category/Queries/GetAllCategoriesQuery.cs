// Create a new query class for getting all categories
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Domain.ModelEntity;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace AspNetCoreCA.Application.Features.Category.Queries
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDTO>>
    {
    }

    // Create a query handler for the new query
    internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler()
        {
        }

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();

            // Assuming there is a mapping function to map Category entities to CategoryDTO
            var categoryDtos = categories.Select(category => _mapper.Map<CategoryDTO>(category)).ToList();

            return categoryDtos;
        }
    }

}