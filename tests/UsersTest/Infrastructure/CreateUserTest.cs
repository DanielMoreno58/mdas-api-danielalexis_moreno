using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using System.Text;

namespace UsersTest.Infrastructure
{
    public class CreateUserTest
    {

        private static HttpClient client = new HttpClient();

        [Fact, Trait("Type", "Acceptance")]
        private void Should_Create_New_User()
        {
            var tuple = Create_New_User();
            Assert.True(tuple.Item1.IsSuccessStatusCode);
        }

        public Tuple<HttpResponseMessage, Guid> Create_New_User()
        {
            HttpClient httpClient = new HttpClient();
            string postUrl = "http://userfavorite:80/api/v1/users";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Guid userId = Guid.NewGuid();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, postUrl);
            request.Content = new StringContent("{\"name\":\"Jonh Doe\",\"id\":\"" + userId + "\"}",
                                                Encoding.UTF8,
                                                "application/json");
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();
            return Tuple.Create(response, userId);
        }
    }
}

