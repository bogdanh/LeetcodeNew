using Library;

namespace Formation {
    
    public class BinarySearchArray {
        public static void Run() {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 20 };
            AssortedMethods.PrintIntArray(arr);
            var k = 11;

            var result = Solution(arr, k);
            Console.WriteLine($"{k} found at position {result}");
        }
        
        private static int Solution(int[] arr, int k) {
            if (arr.Length == 0) {
                return -1;
            }
            
            var left = 0;
            var right = arr.Length - 1;
            
            while (left < right) {
                var mid = left + (right - left) / 2;
                
                if (arr[mid] == k) {
                    return mid;
                }
                
                if (arr[mid] < k) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
