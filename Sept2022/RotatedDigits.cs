// https://leetcode.cn/problems/rotated-digits/

using CommonStructure;

namespace Sept2022 {
    public class RotatedDigits : ITestable {
        public void RunTest() {
            var tests = new int[] { 10, 1, 2 };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.RotatedDigits(test));
        }
        public class Solution {
            static readonly int[] check = { 0, 0, 1, -1, -1, 1, 1, -1, 0, 1 };
            public int RotatedDigits(int n) {
                int ans = 0;
                for (int i = 1; i <= n; ++i) {
                    string num = i.ToString();
                    bool valid = true, diff = false;
                    foreach (char c in num) {
                        if (check[c - '0'] == -1) valid = false;
                        else if (check[c - '0'] == 1) diff = true;
                    }
                    if (valid && diff) ++ans;
                }
                return ans;
            }
        }
    }
}
