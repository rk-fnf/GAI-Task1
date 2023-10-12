using AutoMapper;
using EmployeeForm.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Queries.GetAllEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeRepository;
        private readonly IMapper _mapper;
        public GetEmployeeQueryHandler(IEmployeeRepository employeRepository, IMapper mapper)
        {
            _employeRepository = employeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var employee = await _employeRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<EmployeeDto>>(employee);

            // return list of DTO object
            return data;
        }
    }
}
