using EmployeeForm.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace EmployeeFormUI.Services
{
    public class CreateUserBase : ComponentBase
    {
        public Employee user = new Employee();
        public List<Employee> users = new List<Employee>();

        public async Task CreateUserInfo()
        {
            var httpClient = new HttpClient();
            //POST request to create the user
            var response = await httpClient.PostAsJsonAsync("https://employeedetailsapi.azurewebsites.net/Employee", user);

            if (response.IsSuccessStatusCode)
            {
                users.Add(user);
                user = new Employee();
            }
        }
    }
}
