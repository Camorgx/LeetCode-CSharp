using CommonStructure;

namespace Sept2022 {
    public class ZeroMatrixLcci : ITestable {
        public void RunTest() {
            var tests = new int[][][] {
                new int[][] {
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 0, 1 },
                    new int[] { 1, 1, 1 }
                },
                new int[][] {
                    new int[] { 0, 1, 2, 0 },
                    new int[] { 3, 4, 5, 2 },
                    new int[] { 1, 3, 1, 5 }
                }
            };
            var solution = new Solution();
            foreach (var test in tests) {
                solution.SetZeroes(test);
                foreach (var arr in test) {
                    foreach (int x in arr)
                        Console.Write($"{x} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public class Solution {
            public void SetZeroes(int[][] matrix) {
                bool[] row = new bool[matrix.Length];
                bool[] col = new bool[matrix[0].Length];
                for (int i = 0; i < matrix.Length; ++i) 
                    for (int j = 0; j < matrix[i].Length; ++j)
                        if (matrix[i][j] == 0) {
                            row[i] = true;
                            col[j] = true;
                        }
                for (int i = 0; i < matrix.Length; ++i)
                    for (int j = 0; j < matrix[i].Length; ++j)
                        if (row[i] || col[j])
                            matrix[i][j] = 0;
            }
        }
    }
}
