using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Repositories.Contracts.Notification
{
    public interface INotifyService
    {
        public  Task InsertTextToMessegeQueue(string content);
    }
}
