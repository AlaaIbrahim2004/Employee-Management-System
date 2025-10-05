using AutoMapper;
using BusinessLogic.DTO.Employees;
using DataAccess.Models.Employees;

namespace BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dis => dis.DepartmentName, options => options.MapFrom(src => src.Department == null ? "No Department" : src.Department.Name));
        }
    }
}
