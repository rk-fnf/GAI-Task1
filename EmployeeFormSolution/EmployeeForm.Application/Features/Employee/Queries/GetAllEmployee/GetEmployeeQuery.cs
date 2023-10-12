using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Queries.GetAllEmployee
{
    public record GetEmployeeQuery:IRequest<List<EmployeeDto>>
    {
    }
}
