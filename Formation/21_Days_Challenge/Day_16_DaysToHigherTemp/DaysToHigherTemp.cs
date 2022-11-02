using Library;

namespace Formation {

    public class DaysToHigherTemp {
        public static void Run() {
            var arr = new int[] { 50, 55, 53, 52, 60, 65, 63 };
            AssortedMethods.PrintIntArray(arr);
            var result = Solution(arr);
            AssortedMethods.PrintIntArray(result);
        }
        
        private static int[] Solution(int[] arr) {
            if (arr.Length == 0) {
                return new int[] { };
            }

            var result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++) {
                var highTemp = arr[i];
                var count = 0;

                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[j] > highTemp) {
                        count = j - i;
                        break;
                    }
                }
                result[i] = count;
            }
            return result;
        }
    }
}
