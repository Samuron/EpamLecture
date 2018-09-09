using HelloWorld.Web;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorld.Tests
{
    public class HelloWorldTests
    {
        private HttpClient _client;

        public HelloWorldTests()
        {
            var builder = Program.CreateWebHostBuilder(Array.Empty<string>());
            var server = new TestServer(builder);
            _client = server.CreateClient();
        }

        [Fact]
        public async Task CanGetHelloWorld()
        {
            var response = await _client.GetStringAsync("/");
            Assert.Equal("Hello World!", response);
        }
    }
}
