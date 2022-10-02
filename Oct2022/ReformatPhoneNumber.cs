// https://leetcode.cn/problems/reformat-phone-number/

using CommonStructure;

namespace Oct2022 {
    public class ReformatPhoneNumber : ITestable {
        public void RunTest() {
            var tests = new string[] {
                "1-23-45 6",
                "123 4-567",
                "123 4-5678",
                "12",
                "--17-5 229 35-39475 "
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.ReformatNumber(test));
        }
        public class Solution {
            public string ReformatNumber(string number) {
                IList<char> chars = new List<char>();
                foreach (char c in number)
                    if (c != ' ' && c != '-')
                        chars.Add(c);
                char[] num = chars.ToArray();
                int index = 0;
                IList<string> numbers = new List<string>();
                while (chars.Count - index > 4) {
                    numbers.Add(new string(num, index, 3));
                    index += 3;
                }
                switch (chars.Count - index) {
                    case 2:
                        numbers.Add(new string(num, index, 2));
                        break;
                    case 3:
                        numbers.Add(new string(num, index, 3));
                        break;
                    case 4:
                        numbers.Add(new string(num, index, 2));
                        numbers.Add(new string(num, index + 2, 2));
                        break;
                    default: break;
                }
                string ans = "";
                for (int i = 0; i < numbers.Count - 1; ++i) 
                    ans += numbers[i].ToString() + '-';
                return ans + numbers.Last();
            }
        }
    }
}