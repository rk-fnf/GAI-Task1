using EmployeeForm.Application.Features.Employee.Queries.GetAllEmployee;
using EmployeeForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeForm.Application.Features.Employee.Queries.GetEmployeeDetails;
using EmployeeForm.Application.Features.Employee.Command.CreateEmployee;
using EmployeeForm.Application.Features.Employee.Command.UpdateEmployee;

namespace EmployeeForm.Application.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee,EmployeeDetailsDto>();
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}
