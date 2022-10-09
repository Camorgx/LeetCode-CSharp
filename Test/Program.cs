using CommonStructure;
using Oct2022;

namespace Test {
    internal class Program {
        static void Main() {
            ITestable test = new ScoreOfParentheses();
            test.RunTest();
        }
    }
}