using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using System.Text;

namespace TypeTests.infraestructure
{
    public class TypeGetTest
    {

        [Fact, Trait("Type", "Acceptance")]
        public void Should_Get_Type_Pokemon()
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://pokemon:80/api/v1/TypeGet";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent("{\"name\":\"charizard\"}",
                                                Encoding.UTF8,
                                                "application/json");
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();
            Console.WriteLine(response);
        }
    }
}

