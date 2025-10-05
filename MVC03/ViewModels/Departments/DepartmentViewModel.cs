using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = null!;
        [Range(10, int.MaxValue)]

        public string Code { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public DateOnly DateofCreation { get; set; }

    }
}
