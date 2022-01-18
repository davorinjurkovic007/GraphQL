using GraphQLDemo.API.Services;
using GraphQLDemo.Common.Models;
using HotChocolate;
using System;

namespace GraphQLDemo.API.GraphQL
{
    public class Mutation
    {
        public Customer AddCustomer(
            [Service] ICustomerRepository _customerRepository, 
            string name, 
            string email, 
            int? code, 
            DateTime createdAt, 
            bool isBlocked) 
        { 
            var customer = new Customer { Name = name, Email = email, Code = code, CreatedAt = createdAt, IsBlocked = isBlocked }; 
            _customerRepository.Add(customer); 
            return customer; 
        }

        public Customer UpdateCustomer(
            [Service] ICustomerRepository _customerRepository, 
            int id, 
            string name, 
            string email, 
            int? code, 
            DateTime? createdAt, 
            bool? isBlocked) 
        { 
            var customerToUpdate = _customerRepository.GetById(id); 
            if (customerToUpdate == null) 
                throw new CustomerNotFoundException() 
                { 
                    Id = id 
                }; 
            
            if (name != null) 
                customerToUpdate.Name = name; 
            if (email != null) 
                customerToUpdate.Email = email; 
            if (code != null) 
                customerToUpdate.Code = code; 
            if (createdAt != null) 
                customerToUpdate.CreatedAt = (DateTime)createdAt; 
            if (isBlocked != null) 
                customerToUpdate.IsBlocked = (bool)isBlocked; 
            _customerRepository.Update(customerToUpdate); 
            return customerToUpdate; 
        }
        
        public Customer Delete(int id, [Service] ICustomerRepository _customerRepository) { var customerToDelete = _customerRepository.GetById(id); if (customerToDelete == null) throw new CustomerNotFoundException() { Id = id }; _customerRepository.Delete(id); return customerToDelete; }
    }
}
