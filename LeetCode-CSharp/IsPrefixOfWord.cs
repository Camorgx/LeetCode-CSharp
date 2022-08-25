// https://leetcode.cn/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/

namespace IsPrefixOfWord {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            Console.WriteLine(
                solution.IsPrefixOfWord("i love eating burger", "burg"));
            Console.WriteLine(
                solution.IsPrefixOfWord("this problem is an easy problem", "pro")); ;
            Console.WriteLine(
                solution.IsPrefixOfWord("i am tired", "you"));
        }
    }
    public class Solution {
        public int IsPrefixOfWord(string sentence, string searchWord) {
            var words = sentence.Split();
            for (int i = 0; i < words.Length; ++i) {
                if (words[i].StartsWith(searchWord))
                    return i + 1;
            }
            return -1;
        }
    }
}
