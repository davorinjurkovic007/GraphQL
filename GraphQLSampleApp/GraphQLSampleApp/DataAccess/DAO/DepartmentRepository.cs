using GraphQLSampleApp.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleApp.DataAccess.DAO
{
    public class DepartmentRepository
    {
        private readonly SampleAppDbContext sampleAppDbContext;

        public DepartmentRepository(SampleAppDbContext sampleAppDbContext)
        {
            this.sampleAppDbContext = sampleAppDbContext;
        }

        public List<Department> GetAllDepartmentOnly()
        {
            return sampleAppDbContext.Department.ToList();
        }

        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return sampleAppDbContext.Department
                .Include(d => d.Employees)
                .ToList();
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await sampleAppDbContext.Department.AddAsync(department);
            await sampleAppDbContext.SaveChangesAsync();
            return department;
        }
    }
}
