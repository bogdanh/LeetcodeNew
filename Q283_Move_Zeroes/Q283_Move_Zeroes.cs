using Library;

namespace Q283_Move_Zeroes {

    public class Q283_Move_Zeroes {
        private static void Solution(int[] nums) {
            int i = 0;
            int j = 0;
            
            while (i < nums.Length) {
                if (nums[i] != 0) {
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    j++;
                }
                i++;
            }
        }
        public static void Run() {
            int[] nums = new int[] { 1, 2, 4, 0, 4, 0, 3, 2, 0 };
            AssortedMethods.PrintIntArray(nums);
            Solution(nums);
            AssortedMethods.PrintIntArray(nums);
        }
    }
}
