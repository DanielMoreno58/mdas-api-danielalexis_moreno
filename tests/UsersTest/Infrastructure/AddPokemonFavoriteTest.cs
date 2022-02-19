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
    public class AddPokemonFavoriteTest
    {

        private static HttpClient client = new HttpClient();

        private CreateUserTest createUserTest = new CreateUserTest();
        
        [Fact, Trait("Type", "Acceptance")]
        private void Should_Add_Pokemon_Favorite()
        {
            // Create User
            HttpClient httpClient = new HttpClient();
            var userTest = createUserTest.Create_New_User();

            // Add pokemon Favorite
            string postUrlFavorite = "http://userfavorite:80/api/v1/users/pokemonfavorite";
            HttpRequestMessage requestFavorite = new HttpRequestMessage(HttpMethod.Post, postUrlFavorite);
            Guid pokemonId = Guid.NewGuid();
            requestFavorite.Content = new StringContent("{\"userId\":\""+userTest.Item2+"\",\"pokemonId\":\""+pokemonId+"\"}",
                                                        Encoding.UTF8,
                                                        "application/json");
            var response = httpClient.SendAsync(requestFavorite).GetAwaiter().GetResult();

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

