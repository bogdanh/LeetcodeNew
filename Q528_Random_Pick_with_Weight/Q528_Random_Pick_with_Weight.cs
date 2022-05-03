using Library;

namespace Q528_Random_Pick_with_Weight {

    public class Q528_Random_Pick_with_Weight {
        
        public static void Run() {
            int[] w = new int[] { 1, 2, 3, 2 };
            AssortedMethods.PrintIntArray(w);
            Solution sol = new Solution(w);
            Console.WriteLine(sol.PickIndex());
            Console.WriteLine(sol.PickIndex());
            Console.WriteLine(sol.PickIndex());
            Console.WriteLine(sol.PickIndex());

            SolutionBinarySearch solBinarySearch = new SolutionBinarySearch(w);
            Console.WriteLine(solBinarySearch.PickIndex());
            Console.WriteLine(solBinarySearch.PickIndex());
            Console.WriteLine(solBinarySearch.PickIndex());
            Console.WriteLine(solBinarySearch.PickIndex());
        }
        
        public class SolutionBinarySearch {
            private int[] prefixSums { get; set; }
            private int totalSum { get; set; }
            private Random rand { get; set; }

            public SolutionBinarySearch(int[] w) {
                int prefixSum = 0;
                rand = new Random();
                prefixSums = new int[w.Length];
                
                for (int i = 0; i < w.Length; i++) {
                    prefixSum += w[i];
                    prefixSums[i] = prefixSum;
                }

                totalSum = prefixSum;
            }
            
            public int PickIndex() {
                int idx = rand.Next(totalSum) + 1;

                int left = 0;
                int right = prefixSums.Length - 1;

                while (left <= right) {
                    int mid = left + (right - left) / 2;
                    if (prefixSums[mid] == idx) {
                        return mid;
                    } else if (prefixSums[mid] < idx) {
                        left = mid + 1;
                    } else {
                        right = mid - 1;
                    }
                }
                return left;
            }
        }
        
        public class Solution {
            private int[] prefixSums { get; set; }
            private int prefixSum{ get; set; }
            
            public Solution(int[] w) {
                prefixSums = new int[w.Length];

                for (int i = 0; i < prefixSums.Length; i++) {
                    prefixSum += w[i];
                    prefixSums[i] = prefixSum;
                }
            }
            
            public int PickIndex() {
                Random rand = new Random();
                double target = rand.Next(prefixSum) + 1;
                int i = 0;

                while (i < prefixSums.Length) {
                    if (target < prefixSums[i]) {
                        return i;
                    }
                    i++;
                }

                return i - 1;
            }
        }
    }
}
