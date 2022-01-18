using System;
using System.Runtime.Serialization;

namespace GraphQLDemo.API.GraphQL
{
    [Serializable]
    internal class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string message) : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int Id { get; set; }
    }
}