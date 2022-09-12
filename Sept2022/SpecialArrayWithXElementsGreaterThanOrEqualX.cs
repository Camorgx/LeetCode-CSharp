using CommonStructure;

namespace Sept2022 {
    public class SpecialArrayWithXElementsGreaterThanOrEqualX
        : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 3, 5 },
                new int[] { 0, 0 },
                new int[] { 0, 4, 3, 0, 4 },
                new int[] { 3, 6, 7, 7, 0 }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.SpecialArray(test));
        }
        public class Solution {
            public int SpecialArray(int[] nums) {
                Array.Sort(nums, (a, b) => b.CompareTo(a));
                for (int i = 1; i < nums.Length; i++)
                    if (nums[i - 1] >= i && nums[i] < i)
                        return i;
                return nums.Last() >= nums.Length ? nums.Length : -1;
            }
        }
    }
}
