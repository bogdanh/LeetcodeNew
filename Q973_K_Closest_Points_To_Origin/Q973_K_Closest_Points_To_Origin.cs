using System;
using System.Text;

namespace Q973_K_Closest_Points_To_Origin {
    public class Q973_K_Closest_Points_To_Origin {
        private static int[][] Solution(int[][] points, int k) {
            int l = 0;
            int r = points.Length - 1;

            while (l < r) {
                int pivotIndex = Partition(points, l, r);
                if (pivotIndex == k) {
                    break;
                }

                if (pivotIndex < k) {
                    l = pivotIndex + 1;
                } else {
                    r = pivotIndex - 1;
                }
            }

            int[][] result = new int[k][];
            for (int i = 0; i < k; i++) {
                result[i] = new int[2];
                result[i] = points[i];
            }

            return result;
        }

        private static int Dist(int[][] points, int i) {
            return points[i][0] * points[i][0] + points[i][1] * points[i][1];
        }

        private static int Partition(int[][] points, int l, int r) {
            int pivot = Dist(points, r);
            int loc = l;

            for (int i = l; i < r; i++) {
                if (Dist(points, i) < pivot) {
                    Swap(points, i, loc);
                    loc++;
                }
            }

            Swap(points, loc, r);
            return loc;
        }

        private static void Swap(int[][] points, int i, int j) {
            int[] tmp = points[i];
            points[i] = points[j];
            points[j] = tmp;
        }

        public static void Run() {
            int[][] points = new int[2][];
            points[0] = new int[] { 1, 3 };
            points[1] = new int[] { -2, 2 };
            int k = 1;

            int[][] result = Solution(points, k);

            StringBuilder sb = new StringBuilder();

            foreach (int[] item in result) {
                sb.Append("(");
                foreach (int elem in item) {
                    sb.Append($"{elem}, ");
                }
                sb.Length = sb.Length - 2;
                sb.Append("), ");
            }

            sb.Length = sb.Length - 2;
            Console.Clear();
            Console.WriteLine(sb.ToString());
        }
    }
}
