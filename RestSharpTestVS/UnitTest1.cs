using FluentAssertions;
using RestSharp;
using RestSharpTestVS.Models;
using System.ComponentModel;
using Xunit.Abstractions;

namespace RestSharpTestVS
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper testOutputHelper;
        
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        [Fact]
        public async Task Test1()
        {
            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            // Rest Client
            var client = new RestClient(restClientOptions);

            // Rest Request
            var request = new RestRequest("Product​/GetProductById​/1");

            //Perform operation
            var response = await client.GetAsync<Product>(request);

            // Assert
            response?.Name.Should().Be("Keyboard");
        }
    }
}