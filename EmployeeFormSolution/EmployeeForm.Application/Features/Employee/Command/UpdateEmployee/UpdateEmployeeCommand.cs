using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Command.UpdateEmployee
{
    public class UpdateEmployeeCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public string PhotoURl { get; set; } = string.Empty;
    }
}
