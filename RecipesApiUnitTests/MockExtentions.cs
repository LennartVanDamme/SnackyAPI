using NSubstitute.Core;

namespace RecipesApiUnitTests
{
    public static class MockExtentions
    {
        public static ConfiguredCall Returns<T>(this Task<List<T>> task, params T[] values)
            => task.Returns(values);
    }
}
