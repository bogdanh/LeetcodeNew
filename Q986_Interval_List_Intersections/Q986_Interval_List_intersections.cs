using System;
using System.Collections.Generic;
using System.Linq;

namespace Q986_Interval_List_Intersections {
    public class Q986_Interval_List_Intersections {

        private static int[][] Solution(int[][] A, int[][] B) {
            IList<int[]> result = new List<int[]>();

            int i = 0;
            int j = 0;

            while (i < A.Length && j < B.Length) {
                int low = Math.Max(A[i][0], B[j][0]);
                int high = Math.Min(A[i][1], B[j][1]);

                if (low <= high) {
                    result.Add(new int[] { low, high });
                }

                if (A[i][1] < B[i][1]) {
                    i++;
                } else {
                    j++;
                }
            }

            return result.ToArray();
        }

        public static void Run() {
            int[][] A = new int[4][];
            A[0] = new int[] { 0, 2 };
            A[1] = new int[] { 5, 10 };
            A[2] = new int[] { 13, 23 };
            A[3] = new int[] { 24, 25 };

            int[][] B = new int[4][];
            B[0] = new int[] { 1, 5 };
            B[1] = new int[] { 8, 12 };
            B[2] = new int[] { 15, 24 };
            B[3] = new int[] { 25, 26 };

            int[][] result = Solution(A, B);
        }
    }
}