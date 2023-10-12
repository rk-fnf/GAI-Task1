using EmployeeForm.Application.Context;
using EmployeeForm.Application.Repositories.Contracts.Employees;
using EmployeeForm.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Repositories.Employees.Queries
{
    public class EmployeeQueryService : IEmployeeQueryService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeQueryService(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}
