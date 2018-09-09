using Expenses.Application;
using Expenses.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Expenses
{
    public class Startup : IStartup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IExpenseRepository, ExpenseRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ExpenseService>();
            return services.BuildServiceProvider(true);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
