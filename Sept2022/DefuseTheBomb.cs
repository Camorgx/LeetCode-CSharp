// https://leetcode.cn/problems/defuse-the-bomb/

using CommonStructure;

namespace Sept2022 {
    public class DefuseTheBomb : ITestable {
        public void RunTest() {
            var tests = new (int[] code, int k)[] {
                (new int[] { 5, 7, 1, 4 }, 3),
                (new int[] { 1, 2, 3, 4 }, 0),
                (new int[] { 2, 4, 9, 3 }, -2)
            };
            var solution = new Solution();
            foreach (var test in tests) {
                var res = solution.Decrypt(test.code, test.k);
                foreach (int x in res)
                    Console.Write($"{x} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] Decrypt(int[] code, int k) {
                int[] ans = new int[code.Length];
                if (k > 0) {
                    for (int i = 0; i < code.Length; ++i) {
                        int sum = 0;
                        for (int j = 1; j <= k; ++j)
                            sum += code[(i + j) % code.Length];
                        ans[i] = sum;
                    }
                }
                else if (k < 0) {
                    k = -k;
                    for (int i = 0; i < code.Length; ++i) {
                        int sum = 0, index = i;
                        for (int j = 1; j <= k; ++j) {
                            if (--index < 0) index = code.Length - 1;
                            sum += code[index];
                        }
                        ans[i] = sum;
                    }
                }
                return ans;
            }
        }
    }
}
