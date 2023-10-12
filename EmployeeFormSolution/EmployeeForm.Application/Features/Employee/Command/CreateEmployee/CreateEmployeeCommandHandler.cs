using AutoMapper;
using EmployeeForm.Application.Contracts.MessegeQueue;
using EmployeeForm.Application.Contracts.Persistence;
using EmployeeForm.Domain;
using MediatR;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Features.Employee.Command.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMessegeQueueSender _msgQusueSender;
        Messages _messege =new Messages();


        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, IMessegeQueueSender msgQusueSender)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _msgQusueSender = msgQusueSender;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            // convert to domain entity object
            var employeetocreate = _mapper.Map<Domain.Employee>(request);

            // add to database
            await _employeeRepository.CreateAsync(employeetocreate);

            //send messge to queue
            var sendMessege = $"{_messege.onAddMessgege}: {employeetocreate.Id}";
            await _msgQusueSender.InsertTextToMessegeQueue(sendMessege);

            // retun record id
            return employeetocreate.Id;

            
        }
    }
}
