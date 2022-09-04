// https://leetcode.cn/problems/factorial-trailing-zeroes/

namespace FactorialTrailingZeroes {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            Console.WriteLine(solution.TrailingZeroes(3));
            Console.WriteLine(solution.TrailingZeroes(5));
            Console.WriteLine(solution.TrailingZeroes(0));
        }
    }
    public class Solution {
        public int TrailingZeroes(int n) {
            int ans = 0;
            while (n > 0) {
                n /= 5;
                ans += n;
            }
            return ans;
        }
    }
}
