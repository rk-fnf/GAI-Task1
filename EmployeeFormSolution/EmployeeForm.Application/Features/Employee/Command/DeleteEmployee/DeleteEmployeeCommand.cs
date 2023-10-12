using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Command.DeleteEmployee
{
    public class DeleteEmployeeCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
