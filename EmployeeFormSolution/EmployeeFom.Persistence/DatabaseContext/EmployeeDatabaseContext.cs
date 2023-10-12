
using EmployeeForm.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFom.Persistence.DatabaseContext
{
    public class EmployeeDatabaseContext:DbContext
    {
        public EmployeeDatabaseContext(DbContextOptions<EmployeeDatabaseContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");

        }
    }
}
