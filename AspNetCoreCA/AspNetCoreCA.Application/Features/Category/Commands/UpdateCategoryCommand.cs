using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Features.Category.Commands
{
    public class UpdateCategroyCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }




        internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategroyCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateCategroyCommand request, CancellationToken cancellationToken)
            {
                var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

                if (existingCategory == null)
                {
                    return 0; // Handle not found scenario
                }

                existingCategory.Name = request.Name; // Ensure proper mapping

                await _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);
                _unitOfWork.Save();

                return (int)existingCategory.Id;
            }

        }
    }
}
