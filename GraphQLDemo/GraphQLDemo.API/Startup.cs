using GraphQLDemo.API.Database;
using GraphQLDemo.API.GraphQL;
using GraphQLDemo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            services.AddDbContext<GraphQLDemoDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"), 
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            });

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
                .AddMutationType<Mutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api");
            });
        }
    }
}
