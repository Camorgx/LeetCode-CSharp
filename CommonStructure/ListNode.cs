namespace CommonStructure {
    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null) {
            this.val = val;
            this.next = next;
        }
        public ListNode(IList<int> data) {
            ListNode p = this;
            for (int i = 0; i < data.Count - 1; ++i) {
                p.val = data[i];
                p.next = new ListNode();
                p = p.next;
            }
            p.val = data.Last();
        }
        public override string ToString() {
            ListNode? p = this;
            string ans = "";
            while (p.next is not null) {
                ans += $"{p.val} -> ";
                p = p.next;
            }
            ans += p.val.ToString();
            return ans;
        }
    }
}
