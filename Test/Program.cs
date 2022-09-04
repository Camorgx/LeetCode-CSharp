using CommonStructure;
using Sept2022;

namespace Test {
    internal class Program {
        static void Main(string[] args) {
            ITestable test = new MaximumLengthOfPairChain();
            test.RunTest();
        }
    }
}