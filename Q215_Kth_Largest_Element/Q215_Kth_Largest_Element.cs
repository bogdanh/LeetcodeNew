using System.Collections;
using Library;

namespace Q215_Kth_Largest_Element {

    public class Q215_Kth_Largest_Element {

        public static void Run() {
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            AssortedMethods.PrintIntArray(nums);
            Console.WriteLine($"K: {k}");
            int result = Solution(nums, k);
            Console.WriteLine(result);
            result = QuickSelectSolution(nums, k);
            Console.WriteLine(result);
        }

        #region PriorityQueue
        private static int Solution(int[] nums, int k) {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(new MyComparer());

            foreach (int num in nums) {
                pq.Enqueue(num, num);

                if (pq.Count > k) {
                    pq.Dequeue();
                }
            }

            return pq.Peek();
        }
        #endregion PriorityQueue

        #region QuickSelect
        private static int QuickSelectSolution(int[] nums, int k) {
            int l = 0;
            int r = nums.Length - 1;
            int k_smallest = nums.Length - k;

            while (l < r) {
                int pivotIndex = Partition(nums, l, r);

                if (pivotIndex == k_smallest) {
                    return nums[pivotIndex];
                }

                if (pivotIndex < k_smallest) {
                    l = pivotIndex + 1;
                } else {
                    r = pivotIndex - 1;
                }
            }

            return -1;
        }

        private static int Partition(int[] nums, int l, int r) {
            int pivot = nums[r];
            int loc = l;

            for (int i = l; i < r; i++) {
                if (nums[i] < pivot) {
                    Swap(nums, i, loc);
                    loc++;
                }
            }

            Swap(nums, loc, r);

            return loc;
        }

        private static void Swap(int[] nums, int i, int j) {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        #endregion QuickSelect
    }

    public class MyComparer : IComparer<int> {
        public int Compare(int x, int y) {
            return x.CompareTo(y);
        }
    }
}
