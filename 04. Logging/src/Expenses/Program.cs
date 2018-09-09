using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Expenses
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .ConfigureConsoleLogging()
                //.ConfigureSerilogLogging()
                .UseStartup<Startup>();
        }

        private static IWebHostBuilder ConfigureConsoleLogging(this IWebHostBuilder host)
        {
            return host.ConfigureLogging(builder =>
            {
                builder.AddConsole();
            });
        }

        private static IWebHostBuilder ConfigureSerilogLogging(this IWebHostBuilder host)
        {
            return host.ConfigureLogging(builder =>
            {
                var logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                    {
                        IndexFormat = "expenses-{0:yyyy.MM.dd}",
                    }).CreateLogger();

                builder.AddSerilog(logger);
            });
        }
    }
}
