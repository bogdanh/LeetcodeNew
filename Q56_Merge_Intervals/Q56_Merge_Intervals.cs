using Library;

namespace Q56_Merge_Intervals {

    public class Q56_Merge_Intervals {
        public static void Run() {
            int[][] intervals = new int[4][];
            intervals[0] = new int[] { 1, 3 };
            intervals[1] = new int[] { 2, 6 };
            intervals[2] = new int[] { 8, 10 };
            intervals[3] = new int[] { 15, 18 };

            AssortedMethods.PrintInt2DArray(intervals);
            int[][] result = Solution(intervals);
            AssortedMethods.PrintInt2DArray(result);
        }
        
        private static int[][] Solution(int[][] intervals) {
            Array.Sort(intervals, (int[] a, int[] b) => {
                return a[0].CompareTo(b[0]);
            });

            List<int[]> result = new List<int[]>();

            foreach (int[] interval in intervals) {
                if (result.Count == 0 || result[result.Count - 1][1] < interval[0]) {
                    result.Add(interval);
                } else {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], interval[1]);
                }
            }
            return result.ToArray();
        }
    }
}
