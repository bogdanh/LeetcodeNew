using System.Diagnostics;
using Library;

namespace Counting_Sort {

    public class Counting_Sort {

        private static int[] Solution(int[] nums) {
            int max = int.MinValue;

            foreach (int num in nums) {
                max = Math.Max(max, num);
            }

            int[] arr = new int[max + 1];

            foreach (int num in nums) {
                arr[num]++;
            }

            int[] result = new int[nums.Length];
            int j = 0;
            int i = 0;
            
            while (i < result.Length) {
                while (arr[j] > 0) {
                    result[i] = j;
                    arr[j]--;
                    i++;
                }
                j++;
            }

            return result;
        }

        private static int[] Solution1(int[] nums) {
            int max = int.MinValue;
            
            foreach (int num in nums) {
                max = Math.Max(max, num);
            }

            int[] count = new int[max + 1];
            foreach (int num in nums) {
                count[num]++;
            }

            for (int i = 1; i < count.Length; i++) {
                count[i] += count[i - 1];
            }

            int[] output = new int[nums.Length];

            for (int i = nums.Length - 1; i >= 0; i--) {
                output[count[nums[i]] - 1] = nums[i];
                count[nums[i]]--;
            }

            return output;
        }
        
        public static void Run() {
            int[] nums = new int[] { 10, 2, 5, 4, 2, 3, 4, 2, 0, 10 };
            AssortedMethods.PrintIntArray(nums);

            Console.WriteLine("Solution1:");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int[] result = Solution1(nums);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedTicks);
            AssortedMethods.PrintIntArray(result);

            Console.WriteLine("Solution:");
            Stopwatch secondWatch = new Stopwatch();
            secondWatch.Start();
            result = Solution(nums);
            secondWatch.Stop();
            Console.WriteLine(secondWatch.ElapsedTicks);
            AssortedMethods.PrintIntArray(result);
        }
    }
}
