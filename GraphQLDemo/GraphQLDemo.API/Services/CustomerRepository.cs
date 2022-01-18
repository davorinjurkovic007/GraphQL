using GraphQLDemo.API.Database;
using GraphQLDemo.Common.Models;
using System.Linq;

namespace GraphQLDemo.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GraphQLDemoDbContext dbContext;

        public CustomerRepository(GraphQLDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if(customer != null)
            {
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }
        }

        public IQueryable<Customer> GetAll()
        {
            return dbContext.Customers.AsQueryable();
        }

        public Customer GetById(int id)
        {
            return dbContext.Customers.FirstOrDefault(dbContext => dbContext.Id == id);
        }

        public Customer Update(Customer customer)
        {
            var newCustomer = new Customer(); 
            if (newCustomer.Name != null) 
                newCustomer.Name = customer.Name; 
            
            newCustomer.Code ??= customer.Code; 
            newCustomer.CreatedAt = customer.CreatedAt; 
            if (newCustomer.Email != null) 
                newCustomer.Email = customer.Email; 
            newCustomer.IsBlocked = customer.IsBlocked; 
            dbContext.Customers.Update(customer); 
            dbContext.SaveChanges(); 
            return newCustomer;
        }
    }
}
