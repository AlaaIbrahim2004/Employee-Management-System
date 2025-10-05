using DataAccess.Data;
using DataAccess.Models.Employees;
using DataAccess.Repositories.Generics;

namespace DataAccess.Repositories.Emplooyees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
