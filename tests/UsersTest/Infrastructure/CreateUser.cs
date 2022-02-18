using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using System.Text;
using System.Web.Http;

namespace UsersTest.infraestructure
{
    public class CreateUser
    {

        private static HttpClient client = new HttpClient();
        
        [Fact]
        private async void Should_Create_New_User()
        {

            HttpClient httpClient = new HttpClient();
            string postUrl = "http://localhost:4080/api/v1/users";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Guid id = new Guid();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, postUrl);
            request.Content = new StringContent("{\"name\":\"damian\",\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afb6\"}",
                                                Encoding.UTF8, 
                                                "application/json");
            var resp = httpClient.SendAsync(request).GetAwaiter().GetResult();

            Console.WriteLine(resp);

        }
    }
}

