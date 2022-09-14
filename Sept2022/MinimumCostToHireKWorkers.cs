// https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/

using CommonStructure;

namespace Sept2022 {
    public class MinimumCostToHireKWorkers : ITestable {
        public void RunTest() {
            var tests = new (int[] quality, int[] wage, int k)[] {
                (new int[] { 10, 20, 5 }, new int[] { 70, 50, 30 }, 2),
                (new int[] { 3, 1, 10, 10, 1 }, new int[] { 4, 8, 2, 2, 7 }, 3)
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.MincostToHireWorkers(test.quality, test.wage, test.k));
        }
        public class Solution {
            public double MincostToHireWorkers(int[] quality, int[] wage, int k) {
                int[] workers = new int[quality.Length];
                for (int i = 0; i < quality.Length; ++i) workers[i] = i;
                Array.Sort(workers, (a, b) => quality[b] * wage[a] - quality[a] * wage[b]);
                double totalq = 0;
                var queue = new PriorityQueue<int, int>();
                for (int i = 0; i < k - 1; ++i) {
                    totalq += quality[workers[i]];
                    queue.Enqueue(quality[workers[i]], -quality[workers[i]]);
                }
                double ans = Double.MaxValue;
                for (int i = k - 1; i < quality.Length; ++i) {
                    totalq += quality[workers[i]];
                    queue.Enqueue(quality[workers[i]], -quality[workers[i]]);
                    double totalc = ((double)wage[workers[i]] / quality[workers[i]]) * totalq;
                    ans = Math.Min(ans, totalc);
                    totalq -= queue.Dequeue();
                }
                return ans;
            }
        }
    }
}
