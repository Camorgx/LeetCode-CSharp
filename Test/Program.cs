using CommonStructure;
using Sept2022;

namespace Test {
    internal class Program {
        static void Main() {
            ITestable test = new SerializeAndDeserializeBinaryTree();
            test.RunTest();
        }
    }
}