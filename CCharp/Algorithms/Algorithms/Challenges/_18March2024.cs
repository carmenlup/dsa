using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Challenges
{
    public class _18March2024
    {
        #region received
        /// <summary>
        /// 48. Rotate Image
        /// https://leetcode.com/problems/rotate-image/
        /// Solution:
        ///     - reverse numbers on all diagonals
        ///     - reverse rows
        /// T.C = O(n^2)
        /// S.C = O(n)
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = i; j < matrix[i].Length; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix.Length - 1 - j];
                    matrix[i][matrix.Length - 1 - j] = temp;
                }
            }
        }

        /// <summary>
        /// 283.Move Zeroes
        /// Easy
        /// https://leetcode.com/problems/move-zeroes/description/
        /// Solution : 2 pointer approach
        ///       - one pointer will track the last zero index
        ///       - one is traverse the array (i)
        ///       - swap the values if finds zero
        /// T.C. =  O(n)
        /// S.C = O(1)
        /// </summary>
        /// <param name="input"></param>
        public void MoveZeroes(int[] input)
        {
            var zeroIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != 0)
                {
                    var temp = input[i];
                    input[i] = input[zeroIndex];
                    input[zeroIndex] = temp;
                    zeroIndex++;
                }
            }
        }
        #endregion

        #region proposed
        /// <summary>
        /// Medium
        /// 11. Container With Most Water
        /// https://leetcode.com/problems/container-with-most-water/
        /// T.C = O(n)
        /// S.C = O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            /*
             * looking all the time for max values using 2 pointers and advance the index for min value
             */
            var width = height.Length - 1;
            var max = int.MinValue;
            var i = 0;
            var j = height.Length - 1;
            while (i < j)
            {
                var left = height[i];
                var right = height[j];
                var containerArea = Math.Min(left, right) * width;
                if (max < containerArea)
                    max = containerArea;

                if (height[i] < height[j])
                    i++;
                else
                    j--;

                width--;
            }

            return max;
        }

        /// <summary>
        /// Medium
        /// 189. Rotate Array
        /// https://leetcode.com/problems/rotate-array/
        /// Solution Explained:
        /// https://leetcode.com/problems/rotate-array/solutions/4778158/brute-force-optimal-solution-explained-in-detail-c/
        /// O(n) T; O(1) S
        /// </summary>
        /// <param name="input"></param>
        /// <param name="k"></param>
        public void RotateRight(int[] input, int k)
        {
            /* *
             * end of the array  -> input.Length - 1
             * moving to the right:
             *      First rotation ->  start index = 0; end index = end of array
             *      Second rotation -> start index = 0; end index = k - 1
             *      Third rotation ->  start index = k; end index = end of array
             * moving to the left:
             *      First rotation ->  start index = 0; end index = end of array
             *      Second rotation -> start index = 0; end index = end of the array - k
             *      Third rotation ->  start index = end of the array - k + 1; end index = end of array
             * see RotLeft(List<int> a, int d) for left approach */

            //validation
            if (input.Length == 1)
                return;

            k %= input.Length;
            // move right //[1 2 3 4 5] -> [3 4 5 1 2]
            Reverse(input, 0, input.Length - 1);

            Reverse(input, 0, k - 1);

            Reverse(input, k, input.Length - 1);
        }

        private void Reverse(int[] nums, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                var temp = nums[startIndex];
                nums[startIndex] = nums[endIndex];
                nums[endIndex] = temp;
                startIndex++;
                endIndex--;
            }
        }

        /// <summary>
        /// Left Rotation
        /// https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<int> RotLeft(List<int> a, int d)
        {
            /* moving to the left: start index = a.Length - k: end index = a.Length + (a.length - k)
             * moving to the right: start index = k; end index = a.Length + k
             * see RotateOptimal(int[] input, int k) for right approach */

            // validations
            if (a.Count == 1)
                return a;

            d = d % a.Count;

            //move left //[1 2 3 4 5] -> 3 -> [4 5 1 2 3]
            Reverse(a, 0, a.Count);
            Reverse(a, 0, a.Count - d);
            Reverse(a, a.Count - d, a.Count + (a.Count - d));

            return a;
        }

        private void Reverse(List<int> input, int indexStart, int indexEnd)
        {
            for (var i = indexStart; i < indexEnd / 2; i++)
            {
                var temp = input[i];
                input[i] = input[indexEnd - 1 - i];
                input[indexEnd - 1 - i] = temp;
            }
        }

        #endregion
    }
}
