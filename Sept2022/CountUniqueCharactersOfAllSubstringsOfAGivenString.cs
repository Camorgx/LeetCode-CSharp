// https://leetcode.cn/problems/count-unique-characters-of-all-substrings-of-a-given-string/

using CommonStructure;

namespace Sept2022 {
    public class CountUniqueCharactersOfAllSubstringsOfAGivenString
        : ITestable {
        public void RunTest() {
            Solution solution = new();
            string[] tests = new string[] { "ABC", "ABA", "LEETCODE" };
            foreach (string test in tests)
                Console.WriteLine(solution.UniqueLetterString(test));
        }
        public class Solution {
            public int UniqueLetterString(string s) {
                Dictionary<char, IList<int>> index = new();
                for (int i = 0; i < s.Length; ++i) {
                    if (!index.ContainsKey(s[i])) {
                        index.Add(s[i], new List<int>());
                        index[s[i]].Add(-1);
                    }
                    index[s[i]].Add(i);
                }
                int ans = 0;
                foreach (var pair in index) {
                    var list = pair.Value;
                    list.Add(s.Length);
                    for (int i = 1; i < list.Count - 1; ++i)
                        ans += (list[i] - list[i - 1]) * (list[i + 1] - list[i]);
                }
                return ans;
            }
        }
    }
}
