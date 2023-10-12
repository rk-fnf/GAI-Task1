using AutoMapper;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Application.Execptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryhandler: IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeTypeRepository;
        public GetEmployeeDetailsQueryhandler(IMapper mapper, IEmployeeRepository employeeTypeRepository)
        {
            _mapper = mapper;
            _employeeTypeRepository = employeeTypeRepository;
        }

        public async Task<EmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveType = await _employeeTypeRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (leaveType == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<EmployeeDetailsDto>(leaveType);

            // return DTO object
            return data;
        }
    }
}
