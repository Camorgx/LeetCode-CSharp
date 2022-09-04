// https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/

using CommonStructure;

namespace Sept2022 {
    public class FinalPricesWithASpecialDiscountInAShop
        : ITestable {
        public  void RunTest() {
            int[][] tests = new int[][] {
                new int[] { 8, 4, 6, 2, 3 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 10, 1, 1, 6 }
            };

            Solution solution = new();
            foreach (var test in tests) {
                foreach (var item in solution.FinalPrices(test))
                    Console.Write("{0} ", item);
                Console.WriteLine();
            }
        }

        public class Solution {
            public int[] FinalPrices(int[] prices) {
                for (int i = 0; i < prices.Length; ++i)
                    for (int j = i + 1; j < prices.Length; ++j)
                        if (prices[j] <= prices[i]) {
                            prices[i] -= prices[j];
                            break;
                        }
                return prices;
            }
        }
    }
}
