// https://leetcode.cn/problems/get-kth-magic-number-lcci/submissions/

using CommonStructure;

namespace Sept2022 {
    public class GetTthMagicNumberLcci : ITestable {
        public void RunTest() {
            var tests = new int[] { 1, 5, 7 };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.GetKthMagicNumber(test));
        }
        public class Solution {
            public int GetKthMagicNumber(int k) {
                int index3 = 0, index5 = 0, index7 = 0;
                int[] ans = new int[k];
                ans[0] = 1;
                for (int i = 1; i < k; ++i) {
                    ans[i] = (new int[] 
                        { ans[index3] * 3, ans[index5] * 5, ans[index7] * 7}).Min();
                    if (ans[i] == ans[index3] * 3) ++index3;
                    if (ans[i] == ans[index5] * 5) ++index5;
                    if (ans[i] == ans[index7] * 7) ++index7;
                }
                return ans.Last();
            }
        }
    }
}
