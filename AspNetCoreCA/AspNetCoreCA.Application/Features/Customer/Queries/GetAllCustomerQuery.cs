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

namespace AspNetCoreCA.Application.Features.Customer.Query
{
    public class GetAllCustomerQuery : IRequest<List<CustomerDTO>>
    {
    }

    // Create a query handler for the new query
    // Create a query handler for the new query
    internal class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();

            // Assuming there is a mapping function to map Customer entities to CustomerDTO
            var customerDtos = customers.Select(customer => _mapper.Map<CustomerDTO>(customer)).ToList();

            return customerDtos;
        }
    }

}