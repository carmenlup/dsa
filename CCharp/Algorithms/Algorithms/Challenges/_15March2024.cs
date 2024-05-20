namespace Algorithms.Challenges
{
    public class _15March2024
    {
        #region received
        /// <summary>
        /// Medium
        /// 74 Search a 2D Matrix
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// Solution 1: Brute force
        ///     - traverse the array and compare the element with the target
        ///     - return true if value exists, otherwise false
        /// T.C = O(m * n), where  m = no of rows; n = no of cols
        /// S.C = O(1)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrixBruteForce(int[][] matrix, int target)
        {

            var rowLength = matrix.Length;
            var colLength = matrix[0].Length;

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < colLength; j++)
                {
                    if (matrix[i][j] == target)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Medium
        /// 74 Search a 2D Matrix
        /// Solution 2: Binary search
        ///     Since the matrix contains non-decreased ordered elements we can use binary search
        /// T.C. =  O(log m*n), where  m = no of rows; n = no of cols
        /// S.C =  O(1)
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {

            var rowLength = matrix.Length;
            var colLength = matrix[0].Length;

            var left = 0;
            var right = rowLength * colLength - 1;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;

                var i = middle / colLength;
                var j = middle % colLength;

                if (target == matrix[i][j])
                    return true;

                if (target < matrix[i][j])
                    right = middle - 1;

                if (target > matrix[i][j])
                    left = middle + 1;
            }

            return false;
        }

        /// <summary>
        /// 118. Pascal's Triangle
        /// Easy
        /// https://leetcode.com/problems/pascals-triangle/
        /// Solution 1: Brute force
        ///     - loop first numRows numbers that represents the level of the triangle
        ///     - foreach level compute the next row by sum the 2 numbers
        /// T.C = O(n^3)
        /// S.C = O(n^2)
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (var j = 0; j < numRows; j++)
            {
                IList<int> rowData = new List<int>();
                for (var i = 0; i <= j; i++)
                {
                    if (i == 0 || i == j)
                        rowData.Add(1);
                    else
                        rowData.Add(result[j - 1][i - 1] + result[j - 1][i]);
                }

                result.Add((List<int>)rowData);
            }

            return result;
        }
        #endregion

        #region proposed
        /// <summary>
        /// Easy
        /// 26. Remove Duplicates from Sorted Array
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// This problem is similar to Move zeroes problem
        /// THe pattern is to keep tracking index where the next operation will be done
        /// https://leetcode.com/problems/move-zeroes/description/
        /// Solution
        ///     1. unique index to track first value occurrence
        ///     2. traverse the array and advance unique index when the values are different
        /// T.C -> O(n)
        /// S.C -> O(1)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] input)
        {
            if (input.Length < 1)
                return 0;

            var uniqueIndex = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[uniqueIndex] == input[i])
                    continue;

                uniqueIndex++;
                input[uniqueIndex] = input[i];
            }

            return uniqueIndex + 1;
        }

        /// <summary>
        /// Merge Sorted Array
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="m"></param>
        /// <param name="input2"></param>
        /// <param name="n"></param>
        public void Merge(int[] input1, int m, int[] input2, int n)
        {
            // new[] { 0, 0, 0, 0, 0 }, 0,
            // new[] { 1, 2, 3, 4, 5 }, 5,
            // new[] { 1, 2, 3, 4, 5 })]
            int i = m - 1, j = n - 1, index = m + n - 1;

            if (input2.Length == 0)
                return;

            if (input1.Length == input2.Length)
            {
                while (index >= 0 && input1[index] == 0)
                {
                    input1[index] = input2[index];
                    index--;
                }
                return;
            }

            while (index >= 0 && input1[index] == 0)
            {
                if (input1[i] > input2[j])
                {
                    input1[index] = input1[i];
                    input1[i] = 0;
                    if (i > 0)
                        i--;
                }
                else
                {
                    input1[index] = input2[j];
                    input2[j] = 0;
                    if (j > 0)
                        j--;
                }

                index--;
            }

            var x = 0;
            while (input2[x] != 0)
            {
                input1[x] = input2[x];
                x++;
            }
        }

        #endregion
    }
}
