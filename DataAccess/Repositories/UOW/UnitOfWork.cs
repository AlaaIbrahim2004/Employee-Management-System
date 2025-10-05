using DataAccess.Data;
using DataAccess.Repositories.Departments;
using DataAccess.Repositories.Emplooyees;

namespace DataAccess.Repositories.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IDepartmentRepository> _DepartmentRepository;
        private Lazy<IEmployeeRepository> _EmployeeRepository;
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _DepartmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_appDbContext));
            _EmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_appDbContext));
            _appDbContext = appDbContext;
        }

        public IEmployeeRepository employeeRepository => _EmployeeRepository.Value;

        public IDepartmentRepository departmentRepository => _DepartmentRepository.Value;

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
