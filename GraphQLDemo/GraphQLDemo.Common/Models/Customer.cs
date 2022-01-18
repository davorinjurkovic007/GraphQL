using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDemo.Common.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsBlocked { get; set; }
    }
}
