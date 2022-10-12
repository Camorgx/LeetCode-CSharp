// https://leetcode.cn/problems/linked-list-components/

using CommonStructure;

namespace Oct2022 {
    public class LinkedListComponents : ITestable {
        public void RunTest() {
            var tests = new (ListNode, int[])[] {
                (
                    new ListNode(new int[] { 0, 1, 2, 3 }),
                    new int[] { 0, 1, 3 }
                ),
                (
                    new ListNode(new int[] { 0, 1, 2, 3, 4 }),
                    new int[] { 0, 3, 1, 4 }
                )
            };
            var solution = new Solution();
            foreach (var (head, nums) in tests)
                Console.WriteLine(solution.NumComponents(head, nums));
        }
        public class Solution {
            public int NumComponents(ListNode head, int[] nums) {
                ISet<int> numsSet = new HashSet<int>(nums);
                bool inSet = false;
                int res = 0;
                ListNode? h = head;
                while (h is not null) {
                    if (numsSet.Contains(h.val)) {
                        if (!inSet) {
                            inSet = true;
                            res++;
                        }
                    }
                    else inSet = false;
                    h = h.next;
                }
                return res;
            }
        }
    }
}
