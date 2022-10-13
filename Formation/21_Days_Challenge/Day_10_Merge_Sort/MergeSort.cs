using Library;

namespace Formation {

    public class MergeSort {
        public static void Run() {
            var arr = new int[] { 5, 3, 7, 4, 7, 4, 9, 10 };
            AssortedMethods.PrintIntArray(arr);
            arr = Solution(arr);
            AssortedMethods.PrintIntArray(arr);
        }

        private static int[] Solution(int[] arr) {
            if (arr.Length <= 1) {
                return arr;
            }

            var mid = arr.Length / 2;
            var result = new int[arr.Length];
            var left = new int[mid];
            int[] right;

            if (arr.Length % 2 == 0) {
                right = new int[mid];
            } else {
                right = new int[mid + 1];
            }

            for (var i = 0; i < mid; i++) {
                left[i] = arr[i];
            }

            int idx = 0;

            for (var i = mid; i < arr.Length; i++) {
                right[idx++] = arr[i];
            }

            left = Solution(left);
            right = Solution(right);

            result = Merge(left, right);

            return result;
        }
        
        private static int[] Merge(int[] left, int[] right) {
            var result = new int[left.Length + right.Length];

            var leftIndex = 0;
            var rightIndex = 0;
            var idx = 0;
            
            while (leftIndex < left.Length && rightIndex < right.Length) {
                if (left[leftIndex] <= right[rightIndex]) {
                    result[idx++] = left[leftIndex++];
                } else {
                    result[idx++] = right[rightIndex++];
                }
            }
            
            while (leftIndex < left.Length) {
                result[idx++] = left[leftIndex++];
            }
            
            while (rightIndex < right.Length) {
                result[idx++] = right[rightIndex++];
            }
            
            return result;
        }
    }
}
