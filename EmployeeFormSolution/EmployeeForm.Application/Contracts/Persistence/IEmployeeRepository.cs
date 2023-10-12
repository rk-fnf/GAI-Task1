using EmployeeForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Contracts.Persistence
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
    }
}
