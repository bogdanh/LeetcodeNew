using Library;

namespace Q689_Maximum_Sum_of_3_Non_Overlapping_Subarrays {

    public class Q689_Maximum_Sum_of_3_Non_Overlapping_Subarrays {
        public static void Run() {
            //int[] nums = new int[] { 1, 2, 1, 2, 6, 7, 5, 1 };
            //int[] nums = new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] nums = new int[] { 4, 5, 10, 6, 11, 17, 4, 11, 1, 3 };
            int k = 2;

            AssortedMethods.PrintIntArray(nums);
            Console.WriteLine($"k: {k}");
            int[] result = Solution(nums, k);
            AssortedMethods.PrintIntArray(result);
        }

        private static int[] Solution(int[] nums, int k) {
            if (nums == null || nums.Length == 0) {
                return new int[3];
            }

            int len = nums.Length;

            int[] sum = new int[len + 1];
            int[] left = new int[len];
            int[] right = new int[len];
            int[] res = new int[3];
            int max = 0;

            // compute the running sum
            // sum[i] stores the value from index 0 to i - 1
            for (int i = 0; i < len; i++) {
                sum[i + 1] = sum[i] + nums[i];
            }

            // traverse from left to right
            int leftMax = sum[k] - sum[0];
            //left[k - 1] = 0;
            for (int i = k; i < len; i++) {
                if (sum[i + 1] - sum[i + 1 - k] > leftMax) {
                    leftMax = sum[i + 1] - sum[i + 1 - k];
                    left[i] = i + 1 - k;
                } else {
                    left[i] = left[i - 1];
                }
            }

            // traverse from right to left
            int rightMax = sum[len] - sum[len - k];
            right[len - k] = len - k;
            for (int i = len - k - 1; i >= 0; i--) {
                if (sum[i + k] - sum[i] >= rightMax) {
                    right[i] = i;
                    rightMax = sum[i + k] - sum[i];
                } else {
                    right[i] = right[i + 1];
                }
            }

            // consider the middle part where k <= i <= n - 2k
            for (int i = k; i <= len - 2 * k; i++) {
                int l = left[i - 1];
                int r = right[i + k];
                int total = (sum[l + k] - sum[l]) + (sum[i + k] - sum[i]) + (sum[r + k] - sum[r]);
                if (total > max) {
                    max = total;
                    res[0] = l;
                    res[1] = i;
                    res[2] = r;
                }
            }

            return res;
        }
    }
}
