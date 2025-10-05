using DataAccess.Repositories.Departments;
using DataAccess.Repositories.Emplooyees;

namespace DataAccess.Repositories.UOW
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository employeeRepository { get; }
        public IDepartmentRepository departmentRepository { get; }
        public int SaveChanges();
    }
}
