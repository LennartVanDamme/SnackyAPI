using Microsoft.AspNetCore.Mvc;

namespace RecipesApiUnitTests
{
    public static class SnackyAssert
    {
        public static T AssertOkResult<T>(IActionResult actionResult)
        {
            Assert.NotNull(actionResult);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            return Assert.IsType<T>(okResult.Value);
        }

        public static async Task<T> AssertOkResultAsync<T>(Task<IActionResult> actionResult) 
            => AssertOkResult<T>(await actionResult);
        
    }
}
