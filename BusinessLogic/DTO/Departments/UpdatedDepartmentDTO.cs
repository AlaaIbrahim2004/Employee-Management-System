namespace BusinessLogic.DTO.Departments
{
    public class UpdatedDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public string? Description { get; set; } = string.Empty;
        public DateOnly DateofCreation { get; set; }


    }
}
