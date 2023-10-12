using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Domain
{
    public class Messages
    {
        public string onAddMessgege { get; set; } = "New employee was added to the database with Id";
        public string onUpdateMessge { get; set; } = "Existing employee was updated in the database with Emp Id";
        public string onDeleteMessge { get; set; } = "Employee was deleted from the database with Emp Id";
    }
}
