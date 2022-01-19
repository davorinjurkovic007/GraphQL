using GraphQL.Data;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        /// <summary>
        /// The code below creates a so-called descriptor-attribute and allows us to wrap GraphQL 
        /// configuration code into attributes that you can apply to .NET type system members.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="descriptor"></param>
        /// <param name="member"></param>
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
