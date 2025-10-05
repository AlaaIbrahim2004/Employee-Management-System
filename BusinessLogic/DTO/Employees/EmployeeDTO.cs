using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DTO.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string Gender { get; set; } = null!;
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; } = null!;
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; } = null!;

    }
}
