using DataAccess.Models.Departments;

namespace DataAccess.Models.Employees
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDagte { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual string? ImageName { get; set; }

    }
}
