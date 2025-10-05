using BusinessLogic.DTO.Employees;

namespace BusinessLogic.Services.Interfaces
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDTO> GetAllEmployees(string? EmployeeSearchName, bool withTracking = false);

        EmployeeDetailsDTO? GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDTO employeeDTO);
        int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO);

        bool DeleteEmployee(int id);
    }
}
