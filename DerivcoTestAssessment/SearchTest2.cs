
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace CocktailAPITests
{
    [TestFixture]
    public class CocktailAPITests
    {
        private readonly ITestOutputHelper _output;

        public CocktailAPITests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public async Task GetDrinksSearchAPIVodka()

        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");

            var response = await client.ExecuteGetAsync<Ingredient>(request);


        }

        [TestCase("an ingredient is non-alcoholic, Alcohol is yes and ABV is not null")]
        [Fact]
        public async Task TestCaseOne()

        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            var client = new RestClient(restClientOptions);
            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");
            var response = await client.ExecuteGetAsync<IngredientResponse>(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var ingredient = response.Data.ingredients[0];

            ingredient.idIngredient.Should().Be("1");
            ingredient.strIngredient.Should().Be("Vodka");
            ingredient.strDescription.Should().Contain("odka is a distilled beverage composed primarily of water and ethanol, sometimes with traces of impurities and flavorings. Traditionally, vodka is made by the distillation of fermented cereal grains");
            ingredient.strType.Should().Be("Vodka");
            ingredient.strAlcohol.Should().Be("Yes");
            ingredient.strABV.Should().Be("40");



        }
    }
}
