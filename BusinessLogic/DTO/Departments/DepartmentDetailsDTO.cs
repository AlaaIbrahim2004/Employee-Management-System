namespace BusinessLogic.DTO.Departments
{
    public class DepartmentDetailsDTO
    {


        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public string? Description { get; set; } = string.Empty;

        public int CreatedBy { get; set; }
        public DateOnly DateofCreation { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
