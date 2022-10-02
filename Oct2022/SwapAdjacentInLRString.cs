// https://leetcode.cn/problems/swap-adjacent-in-lr-string/

using CommonStructure;

namespace Oct2022 {
    public class SwapAdjacentInLRString : ITestable {
        public void RunTest() {
            var tests = new (string start, string end)[] {
                ("RXXLRXRXL", "XRLXXRRLX")
            };
            var solution = new Solution();
            foreach (var (begin, end) in tests)
                Console.WriteLine(solution.CanTransform(begin, end));
        }
        public class Solution {
            public bool CanTransform(string start, string end) {
                int n = start.Length;
                int i = 0, j = 0;
                while (i < n && j < n) {
                    while (i < n && start[i] == 'X') ++i;
                    while (j < n && end[j] == 'X') ++j;
                    if (i < n && j < n) {
                        if (start[i] != end[j]) return false;
                        if ((start[i] == 'L' && i < j)
                            || (start[i] == 'R' && i > j))
                            return false;
                        ++i; ++j;
                    }
                }
                for (; i < n; ++i)
                    if (start[i] != 'X') return false;
                for (; j < n; ++j)
                    if (end[j] != 'X') return false;
                return true;
            }
        }
    }
}
