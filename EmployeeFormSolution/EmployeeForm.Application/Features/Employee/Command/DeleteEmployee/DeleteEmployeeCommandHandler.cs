using EmployeeForm.Application.Contracts.MessegeQueue;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Application.Execptions;
using EmployeeForm.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMessegeQueueSender _msgQueueSender;
        Messages _messege = new Messages();
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMessegeQueueSender msgQueueSender)
        {
            _employeeRepository = employeeRepository;
            _msgQueueSender = msgQueueSender;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (employeeToDelete == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            // remove from database
            await _employeeRepository.DeleteAsync(employeeToDelete);

            //send messge to queue
            var sendMessege = $"{_messege.onDeleteMessge}: {employeeToDelete.Id}";
            await _msgQueueSender.InsertTextToMessegeQueue(sendMessege);

            // retun record id
            return Unit.Value;
        }
    }
}
