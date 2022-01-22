using Microsoft.EntityFrameworkCore;

namespace GraphQL.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        /// <summary>
        /// The UseDbContext will create a new middleware that handles scoping for a field. 
        /// The create part will rent from the pool a DBContext, the dispose part will return 
        /// it after the middleware is finished. All of this is handled transparently through 
        /// the new IDbContextFactory<T> introduced with .NET 5.
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor) where TDbContext : DbContext
            {
                return descriptor.UseScopedService<TDbContext>(
                    create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
                    disposeAsync: (s, c) => c.DisposeAsync());
            }

        public static IObjectFieldDescriptor UseUpperCase(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor.Use(next => async context =>
            {
                await next(context);

                if (context.Result is string s)
                {
                    context.Result = s.ToUpperInvariant();
                }
            });
        }
    }
}
