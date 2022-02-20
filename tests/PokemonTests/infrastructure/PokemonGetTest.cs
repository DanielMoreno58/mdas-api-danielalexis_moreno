using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;


namespace PokemonTests.Infrastructure
{
    public class PokemonGetTest
    {

        private static HttpClient client = new HttpClient();

        [Fact, Trait("Type", "Acceptance")]
        private void Should_Get_A_Pokemon_By_Its_Id()
        {
            HttpClient httpClient = new HttpClient();
            string getUrl = "http://pokemon:80/api/v1/pokemon/1";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Guid id = Guid.NewGuid();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, getUrl);
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();
            Assert.True(response.IsSuccessStatusCode);
        }
    }

}