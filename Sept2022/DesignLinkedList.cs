using CommonStructure;
using System.Collections;
using System.Reflection;

namespace Sept2022 {
    public class DesignLinkedList : ITestable {
        public void RunTest() {
            var tests = new (string[] funcName, object[][] args)[] {
                (
                    new string[] { 
                        "AddAtHead", "AddAtTail",
                        "AddAtIndex", "Get", "DeleteAtIndex", "Get" 
                    },
                    new object[][] {
                        new object[] { 1 }, new object[] { 3 },
                        new object[] { 1, 2 }, new object[] { 1 },
                        new object[] { 1 }, new object[] { 1 }
                    }
                ),
                (
                    new string[] {
                        "AddAtHead", "AddAtTail", "AddAtHead", "AddAtTail",
                        "AddAtHead", "AddAtHead", "Get", "AddAtHead", 
                        "Get", "Get", "AddAtTail"
                    },
                    new object[][] {
                        new object[] { 7 }, new object[] { 7 },
                        new object[] { 9 }, new object[] { 8 },
                        new object[] { 6 }, new object[] { 0 },
                        new object[] { 5 }, new object[] { 0 },
                        new object[] { 2 }, new object[] { 5 },
                        new object[] { 4 }
                    }
                ),
                (
                    new string[] {
                        "AddAtHead", "AddAtHead", "AddAtHead", "AddAtIndex",
                        "DeleteAtIndex", "AddAtHead", "AddAtTail", "Get", 
                        "AddAtHead","AddAtIndex","AddAtHead"
                    },
                    new object[][] {
                        new object[] { 7 }, new object[] { 2 },
                        new object[] { 1 }, new object[] { 3, 0 },
                        new object[] { 2 }, new object[] { 6 },
                        new object[] { 4 }, new object[] { 4 },
                        new object[] { 4 }, new object[] { 5, 0 },
                        new object[] { 6 }
                    }
                )
            };
            Type listType = typeof(MyLinkedList);
            int cnt = 0;
            foreach (var test in tests) {
                Console.WriteLine($"Test case {++cnt}\n");
                var list = new MyLinkedList();
                var funcName = test.funcName;
                var args = test.args;
                for (int i = 0; i < funcName.Length; ++i) {
                    Console.Write($"{funcName[i]} ");
                    foreach (object arg in args[i])
                        Console.Write($"{arg} ");
                    Console.WriteLine();
                    MethodInfo? method = listType.GetMethod(funcName[i]);
                    if (method != null)
                        method.Invoke(list, args[i]);
                    DisplayList(list);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        private static void DisplayList(MyLinkedList list) {
            Console.Write("List: ");
            foreach (int item in list)
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine($"Size = {list.Size}");
        }
        public class MyLinkedList : IEnumerable {
            private int size;
            public int Size => size;
            private class ListNode {
                public int data = 0;
                public ListNode? next = null;
                public ListNode? prev = null;
                public ListNode(int data = 0, 
                    ListNode? next = null, ListNode? prev = null) {
                    this.data = data;
                    this.next = next;
                    this.prev = prev;
                }
            }
            /// <summary>
            /// 指向列表中的第一个元素
            /// </summary>
            private ListNode? head = null;
            private ListNode? tail = null;
            private ListNode? GetNodeByIndex(int index) {
                if (index >= Size) return null;
                ListNode? ans;
                if (index <= Size / 2) {
                    ans = head;
                    for (int i = 0; i < index; ++i) {
                        if (ans == null) return null;
                        ans = ans.next;
                    }
                }
                else {
                    int cnt = Size - index - 1;
                    ans = tail;
                    for (int i = 0; i < cnt; ++i) {
                        if (ans == null) return null;
                        ans = ans.prev;
                    }
                }
                return ans;
            }
            public int Get(int index) {
                ListNode? node = GetNodeByIndex(index);
                if (node == null) return -1;
                return node.data;
            }
            public void AddAtHead(int val) {
                ListNode newNode = new(val, head, null);
                if (head == null) {
                    tail = head = newNode;
                    ++size;
                    return;
                }
                head.prev = newNode;
                head = newNode;
                ++size;
            }
            public void AddAtTail(int val) {
                ListNode newNode = new(val, null, tail);
                if (tail == null) {
                    head = tail = newNode;
                    ++size;
                    return;
                }
                tail.next = newNode;
                tail = newNode;
                ++size;
            }
            public void AddAtIndex(int index, int val) {
                if (index > Size) return;
                else if (index <= 0) AddAtHead(val);
                else if (index == Size) AddAtTail(val);
                else {
                    ListNode? node = GetNodeByIndex(index);
                    if (node == null) return;
                    ListNode newNode = new(val, node, node.prev);
                    if (node.prev != null) {
                        node.prev.next = newNode;
                        node.prev = newNode;
                    }
                    ++size;
                }
            }
            public void DeleteAtIndex(int index) {
                if (head == null || tail == null) return;
                if (index == 0) head = head.next;
                else if (index == Size - 1) tail = tail.prev;
                else {
                    ListNode? node = GetNodeByIndex(index);
                    if (node == null) return;
                    if (node.prev != null) node.prev.next = node.next;
                    if (node.next != null) node.next.prev = node.prev;
                }
                --size;
            }
            class Enumrator : IEnumerator {
                private ListNode? node;
                private readonly MyLinkedList list;
                private bool first = true;
                public Enumrator(MyLinkedList list) {
                    node = list.head;
                    this.list = list;
                }
                public object Current => node == null ? 0 : node.data;
                public bool MoveNext() {
                    if (node == null) return false;
                    if (first) {
                        first = false;
                        return true;
                    }
                    if (node.next == null) return false;
                    node = node.next;
                    return true;
                }
                public void Reset() {
                    node = list.head ?? new ListNode();
                }
            }
            IEnumerator IEnumerable.GetEnumerator() {
                return new Enumrator(this);
            }
        }
    }
}
