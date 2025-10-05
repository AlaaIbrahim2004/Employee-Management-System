using BusinessLogic.DTO.Departments;
using BusinessLogic.factories;
using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.UOW;

namespace BusinessLogic.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _unitOfWork.departmentRepository.GetAll();
            var r = departments.Select(D => D.ToDepartmentDTO());
            return r;
        }
        public DepartmentDetailsDTO? SetDepartmentDetailsById(int id)
        {
            var d = _unitOfWork.departmentRepository.GetById(id);
            return d == null ? null : d.ToDepartmentDetailsDTO();

        }
        public int AddDepartment(CreatedDepartmentDTO d)
        {
            _unitOfWork.departmentRepository.Add(d.ToEntity());
            return _unitOfWork.SaveChanges();
        }
        public int UpdateDepartment(UpdatedDepartmentDTO d)
        {
            _unitOfWork.departmentRepository.Update(d.ToEntity());
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteDepartment(int id)
        {
            var d = _unitOfWork.departmentRepository.GetById(id);
            if (d == null) return false;
            d.IsDeleted = true;
            _unitOfWork.departmentRepository.Update(d);
            var r = _unitOfWork.SaveChanges();
            if (r > 0) return true;
            return false;
        }
    }
}
