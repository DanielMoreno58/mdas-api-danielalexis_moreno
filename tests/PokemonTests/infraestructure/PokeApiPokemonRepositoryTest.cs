﻿using Pokemon.Pokemon.Domain;
using Pokemon.Pokemon.Infraestructure;
using PokemonTests.infraestructure.Dto;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace PokemonTests.infraestructure
{
    public class PokeApiPokemonRepositoryTest
    {
        [Fact]
        public void Should_Find_A_Pokemon_By_PokemonId()
        {
            //Given
            string pokemonUrl = "https://pokeapi.co/api/v2/pokemon";
            var mockHttp = new MockHttpMessageHandler();
            var pokeApiPokemonDto = PokeApiPokemonDtoMother.Random();
            var response = JsonSerializer.Serialize(pokeApiPokemonDto);
            mockHttp.When($"{pokemonUrl}/{pokeApiPokemonDto.Id}").Respond("application/json", response);
            var httpClient = new HttpClient(mockHttp);
            var pokeApiPokemonRepository = new PokeApiPokemonRepository(httpClient);
            //When
            var pokemon = pokeApiPokemonRepository.Find(new PokemonId(pokeApiPokemonDto.Id));
            //Then
            Assert.Equal(pokeApiPokemonDto.Id, pokemon.PokemonId.Value);            
        }
        [Fact]
        public void Should_Exists_A_Pokemon_By_PokemonId()
        {
            //Given
            string pokemonUrl = "https://pokeapi.co/api/v2/pokemon";
            var mockHttp = new MockHttpMessageHandler();
            var pokeApiPokemonDto = PokeApiPokemonDtoMother.Random();
            var response = JsonSerializer.Serialize(pokeApiPokemonDto);
            mockHttp.When($"{pokemonUrl}/{pokeApiPokemonDto.Id}").Respond("application/json", response);
            var httpClient = new HttpClient(mockHttp);
            var pokeApiPokemonRepository = new PokeApiPokemonRepository(httpClient);
            //When
            var exists = pokeApiPokemonRepository.Exists(new PokemonId(pokeApiPokemonDto.Id));
            //Then
            Assert.True(exists);
        }
    }
}
