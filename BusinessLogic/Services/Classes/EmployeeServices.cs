using AutoMapper;
using BusinessLogic.DTO.Employees;
using BusinessLogic.factories;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models.Employees;
using DataAccess.Repositories.UOW;

namespace BusinessLogic.Services.Classes
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAttachmentService _attachmentService;
        private object _employeeRepository;

        public EmployeeServices(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _attachmentService = attachmentService;
        }
        public IEnumerable<EmployeeDTO> GetAllEmployees(string? EmployeeSearchName, bool withTracking = false)
        {
            IEnumerable<Employee> emp;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                emp = _unitOfWork.employeeRepository.GetAll(withTracking);

            }
            else
            {
                emp = _unitOfWork.employeeRepository.GetAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }
            var EmpTpReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(emp);
            #region IEnumerable

            //var emp = _employeeRepository.GetEnumerable();
            //var EmpTpReturn = emp.Select(E => new EmployeeDTO()
            //{
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email
            //});
            #endregion

            #region Queryable

            //var emp = _employeeRepository.GetQueryable();
            //var EmpTpReturn = emp.Select(E => new EmployeeDTO()
            //{
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email
            //});
            #endregion
            ////var EmpTpReturn = emp.Select(E => new EmployeeDTO()
            ////{
            ////    Id = E.Id,
            ////    Name = E.Name,
            ////    Age = E.Age,
            ////    Email = E.Email,
            ////    IsActive = E.IsActive,
            ////    Salary = E.Salary,
            ////    Gender = E.Gender.ToString(),
            ////    EmployeeType = E.EmployeeType.ToString()

            ////});
            return EmpTpReturn;
        }
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var emp = _unitOfWork.employeeRepository.GetById(id);
            if (emp == null) return null;
            return new EmployeeDetailsDTO()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                Email = emp.Email,
                Address = emp.Address,
                PhoneNumber = emp.PhoneNumber,
                HiringDate = DateOnly.FromDateTime(emp.HiringDagte),
                IsActive = emp.IsActive,
                Gender = emp.Gender.ToString(),
                EmployeeType = emp.EmployeeType.ToString(),
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Department?.Name,
                CreatedBy = emp.CreatedBy,
                CreatedOn = emp.CreatedOn,
                LastModifiedBy = emp.LastModifiedBy,
                LastModifiedOn = emp.LastModifiedOn,
                Image = emp.ImageName
            };
        }

        public int CreateEmployee(CreatedEmployeeDTO employeeDTO)
        {
            var emp = new Employee()
            {
                Name = employeeDTO.Name,
                Age = employeeDTO.Age,
                Address = employeeDTO.Address,
                Salary = employeeDTO.Salary,
                Email = employeeDTO.Email,
                PhoneNumber = employeeDTO.PhoneNumber,
                HiringDagte = employeeDTO.HiringDate.ToDateTime(TimeOnly.MinValue),
                Gender = employeeDTO.Gender,
                EmployeeType = employeeDTO.EmployeeType,
                IsActive = employeeDTO.IsActive,
                DepartmentId = employeeDTO.DepartmentId,
                ImageName = ((employeeDTO.Image is not null) ? _attachmentService.Upload(employeeDTO.Image, "Images") : null)
            };

            _unitOfWork.employeeRepository.Add(emp);
            return _unitOfWork.SaveChanges();
        }


        public bool DeleteEmployee(int id)
        {
            var e = _unitOfWork.employeeRepository.GetById(id);
            if (e == null) return false;
            e.IsDeleted = true;
            _unitOfWork.employeeRepository.Update(e);
            var r = _unitOfWork.SaveChanges();
            if (r > 0) return true;
            return false;
        }

        public int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            _unitOfWork.employeeRepository.Update(updatedEmployeeDTO.ToEntity());
            return _unitOfWork.SaveChanges();
        }
    }
}
