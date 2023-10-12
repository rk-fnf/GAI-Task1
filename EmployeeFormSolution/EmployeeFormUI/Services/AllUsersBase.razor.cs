using EmployeeForm.Domain;

using Microsoft.AspNetCore.Components;
using System.Net.Http;


namespace EmployeeFormUI.Services
{
    public class AllUsersBase : ComponentBase
    {
        public List<Employee> users = new List<Employee>();
        public Employee newUser = new Employee();
        public int? selectedUserId = null;

        //populate input fields for editing
        public void EditUser(Employee user)
        {
            selectedUserId = user.Id;
        }

        //update user data
        public async Task UpdateUserAsync(Employee user)
        {
            var httpClient = new HttpClient();
            //PUT
            var response = await httpClient.PutAsJsonAsync($"https://employeedetailsapi.azurewebsites.net/Employee/{user.Id}", user);

            if (response.IsSuccessStatusCode)
            {
                selectedUserId = null;
            }
        }
        //edit operation
        public void CancelEdit()
        {
            selectedUserId = null; //Clear user
        }
        public RenderFragment RenderField(object value, int userId, string propertyName)
        {
            return builder =>
            {
                if (userId == selectedUserId)
                {
                    builder.OpenElement(0, "input");
                    builder.AddAttribute(1, "class", "form-control");
                    builder.AddAttribute(2, "value", value);
                    builder.AddAttribute(3, "oninput", EventCallback.Factory.CreateBinder<string>(this, newValue => SetProperty(userId, propertyName, newValue), value.ToString()));
                    builder.CloseElement();
                }
                else
                {
                    builder.AddContent(4, value);
                }
            };
        }

        public void SetProperty(int userId, string propertyName, string newValue)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                if (propertyName == "Age")
                {
                    var vaule = newValue;
                    int updatedValue = int.Parse(vaule);

                    typeof(Employee).GetProperty(propertyName)?.SetValue(user, updatedValue);
                }
                else
                {
                    typeof(Employee).GetProperty(propertyName)?.SetValue(user, newValue);
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            var httpClient = new HttpClient();
            //fetch user data
            var response = await httpClient.GetAsync("https://employeedetailsapi.azurewebsites.net/Employee");

            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadFromJsonAsync<List<Employee>>();
            }
        }
        public async void DeleteUserAsync(Employee user)
        {
            var httpClient = new HttpClient();
            //DELETE
            var response = await httpClient.DeleteAsync($"https://employeedetailsapi.azurewebsites.net/Employee/{user.Id}");

            if (response.IsSuccessStatusCode)
            {
                users.Remove(user);
            }
        }

    }
}
