namespace PreimageSizeOfFactorialZeroesFunction {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            Console.WriteLine(solution.PreimageSizeFZF(0));
            Console.WriteLine(solution.PreimageSizeFZF(5));
            Console.WriteLine(solution.PreimageSizeFZF(3));
        }
    }
    public class Solution {
        private int TrailingZeroes(int n) {
            int ans = 0;
            while (n > 0) {
                n /= 5;
                ans += n;
            }
            return ans;
        }
        private int BinarySearch(int k, int l, int r) {
            if (l > r) return r + 1;
            int mid = (l + r) / 2;
            if (TrailingZeroes(mid) < k)
                return BinarySearch(k, mid + 1, r);
            else return BinarySearch(k, l, mid - 1);
        }
        public int PreimageSizeFZF(int k) {
            return BinarySearch(k + 1, 4 * (k + 1), 5 * (k + 1))
                - BinarySearch(k, 4 * k, 5 * k);
        }
    }
}
