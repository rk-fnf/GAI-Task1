using AutoMapper;
using EmployeeForm.Application.Contracts.MessegeQueue;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMessegeQueueSender _msgQueueSender;
        Messages _messege = new Messages();
        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, IMessegeQueueSender msgQusueSender)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _msgQueueSender = msgQusueSender;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // convert to domain entity object
            var employeeTypeToUpdate = _mapper.Map<Domain.Employee>(request);

            // add to database
            await _employeeRepository.UpdateAsync(employeeTypeToUpdate);

            //send messge to queue
            var sendMessege = $"{_messege.onUpdateMessge}: {employeeTypeToUpdate.Id}";
            await _msgQueueSender.InsertTextToMessegeQueue(sendMessege);

            // return Unit value
            return Unit.Value;
        }
    }
}
