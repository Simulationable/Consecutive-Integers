namespace UnitTest
{
    public class ConsecutiveIntegerTests
    {
        [Theory]
        [InlineData(2, new[] { 14, 15 })]
        [InlineData(3, new[] { 644, 645, 646 })]
        [InlineData(4, new[] { 134043, 134044, 134045, 134046 })]
        public void Test_FindConsecutiveIntegers(int consecutiveCount, int[] expectedResult)
        {
            var result = Program.FindConsecutiveIntegers(consecutiveCount);
            Assert.Equal(expectedResult, result);
        }
    }
}