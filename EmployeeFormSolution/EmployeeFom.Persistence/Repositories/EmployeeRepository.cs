using EmployeeFom.Persistence.DatabaseContext;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFom.Persistence.Repositories
{
    public class EmployeeRepository:GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDatabaseContext context):base(context)
        {
            
        }
    }
}
