using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQL.Extensions
{
    public class UseUpperCaseAttribute : ObjectFieldDescriptorAttribute
    {
        /// <summary>
        /// This new attribute can now be applied to any property or method on a plain C# type.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="descriptor"></param>
        /// <param name="member"></param>
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseUpperCase();
        }
    }
}
