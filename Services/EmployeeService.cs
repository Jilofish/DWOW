using DWOW.Models;
using DWOW.Repositories;

namespace DWOW.Services;

public class EmployeeService : IEmployeeService
{
    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = [
            new () { Avatar = "https://avatar.iran.liara.run/public/35", Name = "John LouisDe Regla", Points = 102, TotalCommends = 45 },
            new () { Avatar = "https://avatar.iran.liara.run/public/44", Name = "Muhammad Abdul", Points = 1100, TotalCommends = 40 },
            new () { Avatar = "https://avatar.iran.liara.run/public/22", Name = "Vitaly Zelenski", Points = 1000, TotalCommends = 35 },
            new () { Avatar = "https://avatar.iran.liara.run/public/11", Name = "Emma Watson", Points = 950, TotalCommends = 30 },
            new () { Avatar = "https://avatar.iran.liara.run/public/55", Name = "Liam Neeson", Points = 900, TotalCommends = 25 },
            new () { Avatar = "https://avatar.iran.liara.run/public/78", Name = "Lil Peep", Points = 420, TotalCommends = 25 },
            new () { Avatar = "https://avatar.iran.liara.run/public/100", Name = "Sadam Husein", Points = 10000, TotalCommends = 999 }

        ];
        return employees;
    }
}
