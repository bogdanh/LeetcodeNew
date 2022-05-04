using Library;

namespace Q523_Continuous_Subarray_Sum {

    public class Q523_Continuous_Subarray_Sum {
        public static void Run() {
            int[] nums = new int[] { 23, 2, 4, 6, 7 };
            int k = 6;
            AssortedMethods.PrintIntArray(nums);
            Console.WriteLine($"k: {k}");
            Console.WriteLine(Solution(nums, k));
        }
        
        /*
        Let's assume d = b - a (b being grater than a). So to have a subarray which sum is multiply of k then we need to find a subarray
        between a and b which mod % k = 0 meaning d % k = 0.
        d = b - a
        d % k = (b - a) % k
        d % k = b % k - a % k
        d % k = 0 => 0 = b % k - a % k
        a % k = b % k
        So if we calculate runningSum for each element in the nums array. If k != 0 we calculate runningSum % k, if runningSum % k (b % k) 
        already exists in the dictionary (a % k) then check if there are already 2 elements between these two position is at least 2.
        If yes return true, otherwise add to the dictionary the runningSum % k as key and index i as value.
        */
        private static bool Solution(int[] nums, int k) {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1;
            int runningSum = 0;
            
            for (int i = 0; i < nums.Length; i++) {
                runningSum += nums[i];
                if (k > 0) {
                    runningSum %= k;
                }
                
                if (map.ContainsKey(runningSum) && i - map[runningSum] > 1) {
                    return true;
                }

                map[runningSum] = i;
            }

            return false;
        }
    }
}
