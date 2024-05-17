using AutoMapper;
using Bogus;
using NSubstitute;
using SnackyAPI.Controllers;
using SnackyAPI.Models.Database;
using SnackyAPI.Services;

namespace RecipesApiUnitTests.Controllers
{
    public class RecipesControllerTests
    {
        private readonly SnacksController controller;
        private readonly IMapper mapperMock;
        private readonly ISnacksService recipesServiceMock;

        private readonly Faker<Snack> recipeFaker;

        public RecipesControllerTests()
        {
            mapperMock = Substitute.For<IMapper>();
            recipesServiceMock = Substitute.For<ISnacksService>();

            controller = new SnacksController(mapperMock, recipesServiceMock);

            recipeFaker = new Faker<Snack>()
                .RuleFor(r => r.Id, f => f.Random.Int())
                .RuleFor(r => r.Name, f => f.Commerce.Product())
                .RuleFor(r => r.ImagePath, f => f.Image.PicsumUrl())
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph());
        }


        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            recipesServiceMock.GetAll().Returns(recipeFaker.Generate(3));

            List<Snack> recipes = await SnackyAssert.AssertOkResultAsync<List<Snack>>(controller.GetRecipes());
            Assert.All(recipes, AssertRecipeInitialize);
        }

        private void AssertRecipeInitialize(Snack recipe)
        {
            Assert.NotEqual(default, recipe.Id);
            Assert.NotEmpty(recipe.Name);
            Assert.NotEmpty(recipe.Description);
            Assert.NotEmpty(recipe.ImagePath);
        }
    }
}