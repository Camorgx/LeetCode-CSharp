// https://leetcode.cn/problems/crawler-log-folder/

using CommonStructure;

namespace Sept2022 {
    public class CrawlerLogFolder : ITestable {
        public void RunTest() {
            string[][] tests = new string[][] {
                new string[] { "d1/", "d2/", "../", "d21/", "./" },
                new string[] { "d1/", "d2/", "./", "d3/", "../", "d31/" },
                new string[] { "d1/", "../", "../", "../" },
                new string[] { "./", "../", "./" }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.MinOperations(test));
        }
        public class Solution {
            public int MinOperations(string[] logs) {
                int ans = 0;
                foreach (string log in logs) {
                    if (log == "./") continue;
                    else if (log == "../") ans = ans > 0 ? ans - 1 : 0;
                    else ++ans;
                }
                return ans;
            }
        }
    }
}
