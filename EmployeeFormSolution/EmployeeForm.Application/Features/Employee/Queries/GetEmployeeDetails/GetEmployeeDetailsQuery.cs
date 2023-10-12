using AutoMapper;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Queries.GetEmployeeDetails;


public record GetEmployeeDetailsQuery(int Id) : IRequest<EmployeeDetailsDto>
{
    
}
