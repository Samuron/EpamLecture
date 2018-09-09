using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace HelloWorld.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.ListenLocalhost(5000);
                })
                .Configure(app =>
                {
                    app.Run((httpContext) =>
                    {
                        var bytes = Encoding.UTF8.GetBytes("Hello World!");
                        var response = httpContext.Response;
                        response.StatusCode = 200;
                        response.ContentType = "text/plain";
                        response.ContentLength = bytes.Length;

                        return response.Body.WriteAsync(bytes, 0, bytes.Length);
                    });
                });
        }
    }
}
