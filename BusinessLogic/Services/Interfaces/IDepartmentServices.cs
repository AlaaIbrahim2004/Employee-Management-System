using BusinessLogic.DTO.Departments;

namespace BusinessLogic.Services.Interfaces
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDTO d);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDetailsDTO? SetDepartmentDetailsById(int id);
        int UpdateDepartment(UpdatedDepartmentDTO d);
    }
}