﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Expenses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>();
        }
    }
}
