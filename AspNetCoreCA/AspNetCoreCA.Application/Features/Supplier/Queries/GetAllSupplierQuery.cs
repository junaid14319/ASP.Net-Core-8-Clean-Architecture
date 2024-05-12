// Create a new query class for getting all categories
using AspNetCoreCA.Application.DTOs;
using AspNetCoreCA.Application.IRepositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllSupplierQuery : IRequest<List<SupplierDTO>>
{
}

// Create a query handler for the new query
internal class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, List<SupplierDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSupplierQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<SupplierDTO>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
    {
        var suppliers = await _unitOfWork.SupplierRepository.GetAllAsync();

        // Assuming there is a mapping function to map Category entities to CategoryDTO
        var supplierDtos = suppliers.Select(supplier => _mapper.Map<SupplierDTO>(supplier)).ToList();

        return supplierDtos;
    }
}
