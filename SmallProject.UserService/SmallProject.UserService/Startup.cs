using FluentValidation.AspNetCore;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallProject.UserService.Application.AIP;
using SmallProject.UserService.GraphQLCore;
using SmallProject.UserService.GraphQLCore.Retailer;
using SmallProject.UserService.Infrastructure;
using SmallProject.UserService.Infrastructure.AIP;
using SmallProject.UserService.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallProject.UserService
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // https://dev.to/marceljurtz/fluentvalidation-in-asp-net-core-2jni#:~:text=To%20use%20FluentValidation%2C%20you%20first,and%20you're%20all%20set!
            //services.AddMvc().AddFluentValidation(option => option.RegisterValidatorsFromAssembly(
            //    typeof());

            // Register NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson();

            // Add MVC
            services.AddMvc(x => x.EnableEndpointRouting = false);


            // Add IOptions Pattern for Connections
            var connectionSection = this.Configuration.GetSection("Connections:HeidiSQL_ConnectionString");
            services.Configure<Connections>(connectionSection);

            // Add DbContext
            services.AddDbContext<UserDbContext>(options => options.UseMySQL(connectionSection.Value));

            // Register repositories
            RepositoryAIP.Register(services);

            // Add MediatR
            MediatorAIP.Register(services);

            // Register IDocumentExecuter
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Add GraphQL. This code line will make sure that the GraphQL runs on the /graphql endpoint
            //app.UseGraphQL<RetailerSchema>("/graphql");
        }
    }
}
