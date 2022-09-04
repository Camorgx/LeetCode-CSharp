using CommonStructure;

namespace Sept2022 {
    public class SpecialPositionsInABinaryMatrix
        : ITestable {
        public void RunTest() {
            int[][][] tests = new int[][][] {
                new int[][] {
                    new int[] { 1, 0, 0 },
                    new int[] { 0, 0, 1 },
                    new int[] { 1, 0, 0 }
                },
                new int[][] {
                    new int[] { 1, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 0, 1 }
                },
                new int[][] {
                    new int[] { 0, 0, 0, 1 },
                    new int[] { 1, 0, 0, 0 },
                    new int[] { 0, 1, 1, 0 },
                    new int[] { 0, 0, 0, 0 }
                }
            };
            
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.NumSpecial(test));
        }
        public class Solution {
            public int NumSpecial(int[][] mat) {
                int[] sumRow = new int[mat.Length];
                int[] sumColumn = new int[mat[0].Length];
                for (int i = 0; i < mat.Length; ++i)
                    Array.ForEach(mat[i], x => { sumRow[i] += x; });
                for (int i = 0; i < mat[0].Length; ++i)
                    Array.ForEach(mat, x => { sumColumn[i] += x[i]; });
                int ans = 0;
                for (int i = 0; i < mat.Length; ++i)
                    for (int j = 0; j < mat[0].Length; ++j)
                        if (mat[i][j] == 1 && 
                            sumRow[i] == 1 && sumColumn[j] == 1)
                            ++ans;
                return ans;
            }
        }
    }
}
