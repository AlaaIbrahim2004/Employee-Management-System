using BusinessLogic.DTO.Employees;
using DataAccess.Models.Employees;

namespace BusinessLogic.factories
{
    public static class EmployeeFactory
    {
        public static Employee ToEntity(this CreatedEmployeeDTO e)
        {
            return new Employee()
            {
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                Address = e.Address,
                IsActive = e.IsActive,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HiringDagte = e.HiringDate.ToDateTime(TimeOnly.MinValue),
                Gender = e.Gender,
                EmployeeType = e.EmployeeType

            };
        }
        public static Employee ToEntity(this UpdatedEmployeeDTO e)
        {
            return new Employee()
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                Address = e.Address,
                IsActive = e.IsActive,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HiringDagte = e.HiringDate.ToDateTime(TimeOnly.MinValue),
                Gender = e.Gender,
                EmployeeType = e.EmployeeType,
                DepartmentId = e.DepartmentId
            };
        }
    }
}
