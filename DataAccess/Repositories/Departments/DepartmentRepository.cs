using DataAccess.Data;
using DataAccess.Models.Departments;
using DataAccess.Repositories.Generics;

namespace DataAccess.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dpContext) : base(dpContext)
        {

            _dbContext = dpContext;

        }
    }
}
