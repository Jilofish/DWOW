using DWOW.Models;

namespace DWOW.Repositories;

public interface IEmployeeService
{
    List<Employee> GetAllEmployees();
}
