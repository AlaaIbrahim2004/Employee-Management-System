using BusinessLogic.DTO.Departments;
using DataAccess.Models.Departments;

namespace BusinessLogic.factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department d)
        {
            return new DepartmentDetailsDTO()
            {

                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                CreatedBy = d.CreatedBy,
                LastModifiedBy = d.LastModifiedBy,
                DateofCreation = DateOnly.FromDateTime(d.CreatedOn),
                IsDeleted = d.IsDeleted
            };
        }
        public static DepartmentDTO ToDepartmentDTO(this Department d)
        {
            return new DepartmentDTO()
            {

                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateofCreation = DateOnly.FromDateTime(d.CreatedOn),

            };
        }

        public static Department ToEntity(this CreatedDepartmentDTO d)
        {
            return new Department()
            {


                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                CreatedOn = d.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDTO d)
        {
            return new Department()
            {

                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                CreatedOn = d.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
