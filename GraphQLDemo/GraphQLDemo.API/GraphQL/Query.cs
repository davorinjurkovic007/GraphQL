using GraphQLDemo.API.Services;
using GraphQLDemo.Common.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLDemo.API.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering] 
        [UseSorting] 
        public IQueryable<Customer> Customers([Service] ICustomerRepository _customerRepository) => _customerRepository.GetAll(); 
        public Customer Customer([Service] ICustomerRepository _customerRepository, int id) 
        { 
            var customer = _customerRepository.GetById(id); 
            if (customer == null) 
            { 
                throw new CustomerNotFoundException() 
                { Id = id }; 
            } 
            return customer; 
        }
    }
}
