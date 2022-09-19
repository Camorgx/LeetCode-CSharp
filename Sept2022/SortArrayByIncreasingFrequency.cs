// https://leetcode.cn/problems/sort-array-by-increasing-frequency/

using CommonStructure;

namespace Sept2022 {
    public class SortArrayByIncreasingFrequency : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 3, 1, 1, 2, 2, 2 },
                new int[] { 2, 3, 1, 3, 2 },
                new int[] { -1, 1, -6, 4, 5, -6, 1, 4, 1 }
            };
            Solution solution = new();
            foreach (var test in tests) {
                foreach (var x in solution.FrequencySort(test))
                    Console.Write($"{x} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] FrequencySort(int[] nums) {
                IDictionary<int, int> counter = new Dictionary<int, int>();
                foreach (int num in nums) {
                    if (!counter.ContainsKey(num))
                        counter[num] = 0;
                    ++counter[num];
                }
                Array.Sort(nums, (int i, int j) => {
                    int i_cnt = counter[i];
                    int j_cnt = counter[j];
                    return i_cnt == j_cnt ? j - i : i_cnt - j_cnt;
                });
                return nums;
            }
        }
    }
}
