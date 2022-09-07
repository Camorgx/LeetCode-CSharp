// https://leetcode.cn/problems/rearrange-spaces-between-words/

using CommonStructure;
using System.Text;

namespace Sept2022 {
    public class RearrangeSpacesBetweenWords : ITestable {
        public void RunTest() {
            string[] tests = new string[] {
                "  this   is  a sentence ",
                " practice   makes   perfect",
                "hello   world",
                "  walks  udp package   into  bar a",
                "a",
                "  hello"
            };
            Solution solution = new();
            foreach (string test in tests)
                Console.WriteLine($"\"{solution.ReorderSpaces(test)}\"");
        }
        public class Solution {
            public string ReorderSpaces(string text) {
                string[] strings = text.Split(' ', 
                    StringSplitOptions.TrimEntries | 
                    StringSplitOptions.RemoveEmptyEntries);
                if (strings.Length == 1) 
                    return strings[0] 
                        + new string(' ', text.Length - strings[0].Length);
                int totalLength = 0;
                Array.ForEach(strings, x => { totalLength += x.Length; });
                int sepCount = (text.Length - totalLength) / (strings.Length - 1);
                int append = (text.Length - totalLength) % (strings.Length - 1);
                var sep = new string(' ', sepCount);
                var end = new string(' ', append);
                var ans = new StringBuilder(strings[0]);
                for (int i = 1; i < strings.Length; ++i)
                    ans.Append(sep + strings[i]);
                ans.Append(end);
                return ans.ToString();
            }
        }
    }
}
