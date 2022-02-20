using System.Net.Http;
using System.Text;
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
            string url = "https://pokemon:80/api/v1/TypeGet/charizard";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            //When
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();

            //Then
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

