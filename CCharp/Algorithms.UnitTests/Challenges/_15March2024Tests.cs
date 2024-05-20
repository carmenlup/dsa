using Algorithms.Challenges;

namespace Algorithms.UnitTests.Challenges
{
    public class _15March2024Tests
    {
        [Theory]
        [MemberData(nameof(SearchMatrixData))]
        public void SearchMatrix_ShouldValidateTarget_InAMatrixArray(int[][] input, int target, bool expected)
        {
            var sut = new _15March2024();
            var result = sut.SearchMatrix(input, target);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SearchMatrixData))]
        public void SearchMatrixBruteForce_ShouldValidateTarget_InAMatrixArray(int[][] input, int target, bool expected)
        {
            var sut = new _15March2024();
            var result = sut.SearchMatrixBruteForce(input, target);
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> SearchMatrixData()
        {
            yield return new object[]
            {
                new[]
                {
                    new[] {1, 3, 5, 7},
                    new[] {10, 11, 16, 20},
                    new[] {23, 30, 34, 60}
                }, 3, true
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1, 3, 5, 7},
                    new[] {10, 11, 16, 20},
                    new[] {23, 30, 34, 60}
                }, 16, true
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1, 3, 5, 7},
                    new[] {10, 11, 16, 20},
                    new[] {23, 30, 34, 60}
                }, 80, false
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1},
                    new[] {3},
                }, 2, false
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1},
                    new[] {3},
                }, 3, true
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1, 3, 5, 7},
                    new[] {10, 11, 16, 20},
                    new[] {23, 30, 34, 50}
                }, 24, false
            };
            yield return new object[]
            {
                new[]
                {
                    new[] {1, 3, 5, 7},
                    new[] {10, 11, 16, 20},
                    new[] {23, 30, 34, 50}
                }, 30, true
            };
        }

        [Fact]
        public void PascalTriangle_ShouldReturnSummedNumbers()
        {
            var sut = new _15March2024();
            var expected = new List<List<int>>
            {
                new() { 1 },
                new() { 1, 1},
                new() { 1, 2, 1},
                new() { 1, 3, 3, 1},
                new() { 1, 4, 6, 4, 1},
            };

            var result = sut.Generate(5);
            Assert.Equal(expected[2][1], result[2][1]);
        }

        [Theory]
        [InlineData(new[] { 3, 3 }, 1)]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        [InlineData(new int[] { }, 0)]
        public void RemoveDuplicates_ShouldRemoveDuplicatesAndReturnNumberOfElementInTheNewArray(int[] input, int expected)
        {
            var sut = new _15March2024();
            var actual = sut.RemoveDuplicates(input);
            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData(
            new[] { 1, 2, 3, 0, 0, 0 }, 3,
            new[] { 2, 5, 6 }, 3,
            new[] { 1, 2, 2, 3, 5, 6 })]
        [InlineData(
            new[] { 0, 2, 0, 0 }, 2,
            new[] { 0, 1 }, 2,
            new[] { 0, 0, 1, 2 })]
        [InlineData(
            new[] { 0, 0, 3, 0, 0, 0, 0, 0, 0 }, 3,
            new[] { -1, 1, 1, 1, 2, 3 }, 6,
            new[] { -1, 0, 0, 1, 1, 1, 2, 3, 3 })]
        [InlineData(
            new[] { 0, 0, 0, 0, 0 }, 0,
            new[] { 1, 2, 3, 4, 5 }, 5,
            new[] { 1, 2, 3, 4, 5 })]
        [InlineData(
            new[] { 0 }, 0,
            new[] { 1 }, 1,
            new[] { 1 })]
        [InlineData(
            new int[] { 1 }, 1,
            new int[] {}, 0,
            new int[] {1})]

        public void MergeTwoArrays_ShouldReturnMergedArray_AndKeepIndexItem(
            int[] list1, int m, int[] list2, int n, int[] expected)
        {
            var sut = new _15March2024();

            sut.Merge(list1, m, list2, n);
            
            Assert.Equal(expected, list1);
        }
    }
}
