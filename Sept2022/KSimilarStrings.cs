// https://leetcode.cn/problems/k-similar-strings/

using CommonStructure;

namespace Sept2022 {
    public class KSimilarStrings : ITestable {
        public void RunTest() {
            var tests = new (string s1, string s2)[] {
                ("ab", "ba"),
                ("abc", "bca"),
                ("abccaacceecdeea", "bcaacceeccdeaae")
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(
                    solution.KSimilarity(test.s1, test.s2));
        }
        public class Solution {
            private string Swap(string s, int pos1, int pos2) {
                var chars = s.ToCharArray();
                (chars[pos1], chars[pos2]) = (chars[pos2], chars[pos1]);
                return new string(chars);
            }
            public int KSimilarity(string s1, string s2) {
                var queue = new Queue<(string cur, int pos)>();
                ISet<string> visit = new HashSet<string>();
                queue.Enqueue((s1, 0));
                visit.Add(s1);
                int step = 0;
                while (queue.Count > 0) {
                    int queueSize = queue.Count;
                    for (int i = 0; i < queueSize; ++i) {
                        (string cur, int pos) = queue.Dequeue();
                        if (cur == s2) return step;
                        while (pos < s1.Length && cur[pos] == s2[pos])
                            ++pos;
                        for (int j = pos + 1; j < s1.Length; ++j) {
                            if (s2[j] == cur[j]) continue;
                            if (s2[pos] == cur[j]) {
                                string next = Swap(cur, pos, j);
                                if (!visit.Contains(next)) {
                                    visit.Add(next);
                                    queue.Enqueue((next, pos + 1));
                                }
                            }
                        }
                    }
                    ++step;
                }
                return step;
            }
        }
    }
}
