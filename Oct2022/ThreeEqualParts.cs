// https://leetcode.cn/problems/three-equal-parts/

using CommonStructure;

namespace Oct2022 {
    public class ThreeEqualParts : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 1, 0, 1, 0, 1 },
                new int[] { 1, 1, 0, 1, 1 },
                new int[] { 1, 1, 0, 0, 1 }
            };
            var solution = new Solution();
            foreach (var test in tests) {
                var res = solution.ThreeEqualParts(test);
                foreach (var item in res)
                    Console.Write($"{item} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] ThreeEqualParts(int[] arr) {
                int sum = arr.Sum();
                if (sum % 3 != 0)
                    return new int[] { -1, -1 };
                if (sum == 0)
                    return new int[] { 0, 2 };
                int partial = sum / 3;
                int first = 0, second = 0, third = 0, cur = 0;
                for (int i = 0; i < arr.Length; ++i) {
                    if (arr[i] == 1) {
                        if (cur == 0) first = i;
                        else if (cur == partial) second = i;
                        else if (cur == 2 * partial) third = i;
                        ++cur;
                    }
                }
                int len = arr.Length - third;
                if (first + len <= second && second + len <= third) {
                    for (int i = 0; third + i < arr.Length; ++i)
                        if (arr[first + i] != arr[second + i] || arr[first + i] != arr[third + i])
                            return new int[] { -1, -1 };
                    return new int[] { first + len - 1, second + len };
                }
                return new int[] { -1, -1 };
            }
        }
    }
}
