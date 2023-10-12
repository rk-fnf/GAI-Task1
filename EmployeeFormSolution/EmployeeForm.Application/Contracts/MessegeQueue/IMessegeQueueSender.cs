using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Contracts.MessegeQueue
{
    public interface IMessegeQueueSender
    {
        public Task InsertTextToMessegeQueue(string content);
    }
}
