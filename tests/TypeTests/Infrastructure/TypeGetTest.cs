using System.Net.Http;
using Xunit;

namespace TypeTests.Infrastructure
{
    public class TypeGetTest
    {

        [Fact, Trait("Type", "Acceptance")]
        public void Should_Get_Type_Pokemon()
        {
            //Given
            HttpClient httpClient = new HttpClient();
            string url = "http://pokemon:80/api/v1/TypeGet";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            //When
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();

            //Then
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

