// https://leetcode.cn/problems/find-k-closest-elements/

namespace FindKClosestElements {
    public static class Test {
        private static int BinarySearch(int[] arr, int x) {
            int low = 0, high = arr.Length - 1;
            while (low < high) {
                int mid = low + (high - low) / 2;
                if (arr[mid] >= x) high = mid;
                else low = mid + 1;
            }
            return low;
        }
        public static void RunTest() {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(~Array.BinarySearch(arr, 6));
            Console.WriteLine(BinarySearch(arr, 6));

            Solution solution = new();
            var tests = new IList<int>[] {
                solution.FindClosestElements(arr, 4, 3),
                solution.FindClosestElements(arr, 4, -1)
            };
            foreach (var testCase in tests) {
                foreach (var item in testCase)
                    Console.Write("{0} ", item);
                Console.WriteLine();
            }
        }
    }
    public class Solution {
        public IList<int> FindClosestElements(int[] arr, int k, int x) {
            int right = Array.BinarySearch(arr, x);
            if (right < 0) right = ~right;
            int left = right - 1;
            for (int i = 0; i < k; ++i) {
                if (left < 0) ++right;
                else if (right >= arr.Length) --left;
                else if (x - arr[left] <= arr[right] - x) --left;
                else ++right;
            }
            // ans from left + 1 to right - 1
            return new ArraySegment<int>(arr, left + 1, right - left - 1);
        }
    }
}
