using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SnackyAPI.Models.Database;
using SnackyAPI.Models.DTO;
using System.Text;
using System.Text.Json;

namespace SnackyAPIIntegrationTests
{
    public class SnacksControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public SnacksControllerTests(WebApplicationFactory<Program> factory) 
        {
            this.factory = factory;
        }

        [Fact]
        public async Task GetAll_ReturnsAllTheRecipes()
        {
            var client = factory.CreateClient();

            CreateSnackDTO dto = new CreateSnackDTO
            {
                Description = "Snack description",
                ImagePath = "https://google.com",
                Name = "Bitteballen"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/snacks", content);
            Assert.True(response.IsSuccessStatusCode);

            response = await client.GetAsync("/api/snacks");
            Assert.True(response.IsSuccessStatusCode);

            string responseContent = await response.Content.ReadAsStringAsync();
            List<Snack>? snacks = JsonConvert.DeserializeObject<List<Snack>>(responseContent);
            
            Assert.NotNull(snacks);
            Assert.Collection(snacks, snack =>
            {
                Assert.NotEqual(default, snack.Id);
                Assert.Equal("Bitterballen", snack.Name);
                Assert.Equal("Snack desciprtion", snack.Description);
                Assert.Equal("https://google.com", snack.ImagePath);
            });
        }
    }
}
