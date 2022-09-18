// https://leetcode.cn/problems/making-a-large-island/

using CommonStructure;

namespace Sept2022 {
    public class MakingALargeIsland : ITestable {
        public void RunTest() {
            var tests = new int[][][] {
                new int[][] {
                    new int[] { 1, 0 },
                    new int[] { 0, 1 }
                },
                new int[][] {
                    new int[] { 1, 1 },
                    new int[] { 1, 0 }
                },
                new int[][] {
                    new int[] { 1, 1 },
                    new int[] { 1, 1 }
                }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.LargestIsland(test));
        }
        public class Solution {
            readonly int[] d = { 0, -1, 0, 1, 0 };
            public int LargestIsland(int[][] grid) {
                int n = grid.Length, res = 0;
                int[,] tag = new int[n, n];
                var area = new Dictionary<int, int>();
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        if (grid[i][j] == 1 && tag[i, j] == 0) {
                            int t = i * n + j + 1;
                            area.Add(t, DFS(grid, i, j, tag, t));
                            res = Math.Max(res, area[t]);
                        }
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        if (grid[i][j] == 0) {
                            int tmp = 1;
                            ISet<int> connect = new HashSet<int>();
                            for (int k = 0; k < 4; ++k) {
                                int x = i + d[k], y = j + d[k + 1];
                                if (!Valid(n, x, y) 
                                    || tag[x, y] == 0 || connect.Contains(tag[x, y]))
                                    continue;
                                tmp += area[tag[x, y]];
                                connect.Add(tag[x, y]);
                            }
                            res = Math.Max(res, tmp);
                        }
                return res;
            }
            public int DFS(int[][] grid, int x, int y, int[,] tag, int t) {
                int n = grid.Length, res = 1;
                tag[x, y] = t;
                for (int i = 0; i < 4; ++i) {
                    int x1 = x + d[i], y1 = y + d[i + 1];
                    if (Valid(n, x1, y1) 
                        && grid[x1][y1] == 1 && tag[x1, y1] == 0)
                        res += DFS(grid, x1, y1, tag, t);
                }
                return res;
            }
            public static bool Valid(int n, int x, int y) {
                return x >= 0 && x < n && y >= 0 && y < n;
            }
        }
    }
}
