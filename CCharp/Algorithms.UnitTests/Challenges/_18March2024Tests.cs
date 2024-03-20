using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Challenges;

namespace Algorithms.UnitTests.Challenges
{
    public class _18March2024Tests
    {
        [Theory]
        [MemberData(nameof(RotateMatrix))]
        public void RotateMatrix_Should_RotateMatrix_90DegreeClockwise(int[][] matrix, int[][] expected)
        {
            var sut = new _18March2024();
            sut.Rotate(matrix);
            Assert.Equal(expected, matrix);
        }

        public static IEnumerable<object[]> RotateMatrix()
        {
            yield return new object[]
            {
                new int[][]
                {
                    new int[] {1, 2, 3},
                    new int[] {4, 5, 6},
                    new int[] {7, 8, 9}
                },
                new int[][]
                {
                    new int[] {7, 4, 1},
                    new int[] {8, 5, 2},
                    new int[] {9, 6, 3}
                }
            };
        }

        [Theory]
        [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 1, 1, 1, 2, 2, 3, 3, 4, 0, 0 })]
        public void RemoveDuplicates_ShouldDuplicateZeroValuesInArray(int[] input, int[] expected)
        {
            var sut = new _18March2024();
            sut.MoveZeroes(input);
            Assert.Equal(expected, input);
        }

        [Theory]
        [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void MaxArea_ShouldReturnTheMaxArea_ForTheGivenHeightAndWidth(int[] heights, int expected)
        {
            var sut = new _18March2024();

            var result = sut.MaxArea(heights);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
        public void RotateInRight_ShouldMove_ArrayElementsToRight_KPositions(int[] input, int k, int[] expected)
        {
            var sut = new _18March2024();

            sut.RotateRight(input, k);

            Assert.Equal(expected, input);
        }

        [Theory]
        [MemberData(nameof(RotateArrayLeftData))]
        public void RotateLeft_ShouldMove_ArrayElementsToLeft_KPositions(List<Int32> input, int k, List<int> expected)
        {
            var sut = new _18March2024();

            sut.RotLeft(input, k);

            Assert.Equal(expected, input);
        }

        public static IEnumerable<object[]> RotateArrayLeftData()
        {
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5, 6, 7 },
                3,
                new List<int> { 4, 5, 6, 7, 1, 2, 3 }
            };
        }
    }
}
