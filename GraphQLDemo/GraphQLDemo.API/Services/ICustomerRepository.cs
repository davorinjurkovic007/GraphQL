using GraphQLDemo.Common.Models;
using System.Linq;

namespace GraphQLDemo.API.Services
{
    public interface ICustomerRepository
    {
        void Add(Customer customer); 
        void Delete(int id); 
        IQueryable<Customer> GetAll(); 
        Customer GetById(int id); 
        Customer Update(Customer customer);
    }
}
