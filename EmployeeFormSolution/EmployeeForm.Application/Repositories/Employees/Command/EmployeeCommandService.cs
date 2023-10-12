using EmployeeForm.Application.Context;
using EmployeeForm.Application.Repositories.Contracts.Employees;
using EmployeeForm.Application.Repositories.Notification;
using EmployeeForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Application.Repositories.Employees.Command;

public class EmployeeCommandService : IEmployeeCommandService
{
    private readonly EmployeeDbContext _context;
    private readonly NotifyService _notifyService;
    Messages messages = new Messages(); 

    public EmployeeCommandService(EmployeeDbContext context, NotifyService notifyService)
    {
        _context = context;
        _notifyService = notifyService;
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        var notification = $"{messages.onAddMessgege}: {employee.Id}";
        await _notifyService.InsertTextToMessegeQueue(notification);
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        var notification = $"{messages.onUpdateMessge}: {employee.Id}";
        await _notifyService.InsertTextToMessegeQueue(notification);
        return employee;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            throw new ArgumentException($"Employee with ID {id} not found.");
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        var notification = $"{messages.onDeleteMessge}: {employee.Id}";
        await _notifyService.InsertTextToMessegeQueue(notification);
    }
}
