using Expenses.Application;
using Expenses.Data;
using Expenses.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace Expenses
{
    public class Startup : IStartup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ExpensesContext>(options =>
            {
                var connection = _configuration.GetConnectionString("Expenses");
                options.UseNpgsql(connection);
            });
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ExpenseService>();
            services.AddSwaggerGen(ConfigureSwagger);
            return services.BuildServiceProvider(true);
        }

        private void ConfigureSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new Info
            {
                Title = "Expenses API",
                Description = "Cool application to track beer expenses",
                Version = "v1"
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, "Expenses.xml");
            options.IncludeXmlComments(filePath, true);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expenses API V1"));
        }
    }
}
