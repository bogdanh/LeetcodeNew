using Library;

namespace Q152_Maximum_Product_Subarray {

    public class Q152_Maximum_Product_Subarray {
        public static void Run() {
            int[] nums = new int[] { 2, 3, -2, 4 };
            AssortedMethods.PrintIntArray(nums);

            int result = Solution(nums);
            Console.WriteLine(result);
        }
        
        private static int Solution(int[] nums) {
            if (nums.Length == 0) {
                return 0;
            }
            
            int product = 1;
            int max = int.MinValue;

            for (int i = 0; i < nums[i]; i++) {
                product *= nums[i];
                max = Math.Max(max, product);

                if (product == 0) {
                    product = 1;
                }
            }

            product = 1;

            for (int i = nums.Length - 1; i >= 0; i--) {
                product *= nums[i];
                max = Math.Max(max, product);

                if (product == 0) {
                    product = 1;
                }
            }

            return max;
        }
    }
}
