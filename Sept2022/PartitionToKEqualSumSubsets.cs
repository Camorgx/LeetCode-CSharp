using CommonStructure;

namespace Sept2022 {
    public class PartitionToKEqualSumSubsets : ITestable {
        public void RunTest() {
            var tests = new (int[] nums, int k)[] {
                (new int[] { 4, 3, 2, 3, 5, 2, 1 }, 4),
                (new int[] { 1, 2, 3, 4 }, 3)
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.CanPartitionKSubsets(
                    test.nums, test.k));
        }
    }
    public class Solution {
        public bool CanPartitionKSubsets(int[] nums, int k) {
            int sum = nums.Sum();
            if (sum % k != 0) return false;
            int per = sum / k;
            Array.Sort(nums);
            if (nums.Last() > per) return false;
            bool[] states = new bool[1 << nums.Length];
            Array.Fill(states, true);
            bool DFS(int state, int p) {
                if (state == 0) return true;
                if (!states[state]) return false;
                states[state] = false;
                for (int i = 0; i < nums.Length; ++i) {
                    if (nums[i] + p > per) break;
                    if (((state >> i) & 1) != 0
                        && DFS(state ^ (1 << i), (p + nums[i]) % per))
                        return true;
                }
                return false;
            };
            return DFS((1 << nums.Length) - 1, 0);
        }
    }
}
