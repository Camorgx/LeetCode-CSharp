// https://leetcode.cn/problems/beautiful-arrangement-ii/

using CommonStructure;

namespace Sept2022 {
    public class BeautifulArrangementII : ITestable {
        public void RunTest() {
            var tests = new (int, int)[] { (3, 1), (3, 2) };
            Solution solution = new();
            foreach (var test in tests) {
                var res = solution.ConstructArray(test.Item1, test.Item2);
                foreach (int i in res) Console.Write($"{i} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] ConstructArray(int n, int k) {
                IList<int> list = new List<int>();
                for (int i = 1; i < n - k; i++) 
                    list.Add(i);
                int j = n;
                for (int i = n - k; i <=j; ++i) {
                    list.Add(i);
                    if (i != j) list.Add(j);
                    --j;
                }
                return list.ToArray();
            }
        }
    }
}
