using GraphQLSampleApp.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleApp.DataAccess.DAO
{
    public class EmployeeRepository
    {
        private readonly SampleAppDbContext sampleAppDbContext;

        public EmployeeRepository(SampleAppDbContext sampleAppDbContext)
        {
            this.sampleAppDbContext = sampleAppDbContext;
        }

        public List<Employee> GetEmployees()
        {
            return sampleAppDbContext.Employee.ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            var employee = sampleAppDbContext.Employee
                .Include(e => e.Department)
                .Where(e => e.EmployeeId == id)
                .FirstOrDefault();

            if (employee != null)
                return employee;

            return null;
        }

        public List<Employee> GetEmployeesWithDepartment()
        {
            return sampleAppDbContext.Employee
                .Include(e => e.Department)
                .ToList();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await sampleAppDbContext.Employee.AddAsync(employee);
            await sampleAppDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
