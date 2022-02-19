using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using System.Text;

namespace UsersTest.infraestructure
{
    public class CreateUserTest
    {

        private static HttpClient client = new HttpClient();

        [Fact, Trait("Type", "Acceptance")]
        private void Should_Create_New_User()
        {
            HttpClient httpClient = new HttpClient();
            string postUrl = "http://userfavorite:80/api/v1/users";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Guid id = Guid.NewGuid();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, postUrl);
            request.Content = new StringContent("{\"name\":\"Jonh Doe\",\"id\":\"" + id + "\"}",
                                                Encoding.UTF8,
                                                "application/json");
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

