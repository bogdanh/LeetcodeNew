using Library;

namespace Formation {

    public class MinimumSumTriangle {
        public static void Run() {
            var triangle = new int[4][] {
                // new int[] { 2 },
                // new int[] { 3, 4 },
                // new int[] { 6, 5, 7 },
                // new int[] { 4, 1, 8, 3 }
                new int[] { 1 },
                new int[] { 4, 3 },
                new int[] { 7, 6, 5 },
                new int[] { 4, 1, 8, 3 }
            };

            AssortedMethods.PrintInt2DArray(triangle);
            var result = Solution(triangle);
            Console.WriteLine(result);
            
            result = Solution(triangle);
            Console.WriteLine(result);
        }

        private static int Solution1(int[][] triangle) {
            for (var row = triangle.Length - 2; row >= 0; row--) {
                for (var col = 0; col <= row; col++) {
                    var bestBelow = Math.Min(triangle[row + 1][col], triangle[row + 1][col + 1]);

                    triangle[row][col] += bestBelow;
                }
            }

            return triangle[0][0];
        }
        
        private static int Solution(int[][] triangle) {
            int result = 0;

            if (triangle.Length == 0) {
                return result;
            }

            int i = 1;
            result = triangle[0][0];
            int j = 0;

            while (i < triangle.Length) {
                if (j == triangle[i].Length - 1) {
                    result += triangle[i][j];
                    i++;
                    continue;
                }

                if (triangle[i][j] <= triangle[i][j + 1]) {
                    result += triangle[i][j];
                } else {
                    result += triangle[i][j + 1];
                    j++;
                }
                i++;
            }

            return result;
        }
    }
}