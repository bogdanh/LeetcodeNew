#nullable disable warnings
using System.Diagnostics;

namespace Formation {

    public class SearchInMatrix {
        public static void Run() {
            var test = new Test {
                Id = 1,
                Matrix = new int[5][] {
                    new int[] { 1, 4, 7, 11, 15 },
                    new int[] { 2, 5, 8, 12, 19 },
                    new int[] { 3, 6, 9, 16, 22 },
                    new int[] { 23, 23, 24, 27, 28 },
                    new int[] { 29, 30, 32, 33, 34 }
                },
                Expected = true,
                K = 5
            };

            var result = Solution(test.Matrix, test.K);
            test.Verify(result);
        }
        
        private static bool Solution(int[][] matrix, int k) {
            var rows = matrix.Length;
            if (rows == 0) {
                return false;
            }

            var cols = matrix[0].Length;
            var row = rows - 1;
            var col = 0;
            
            while (row >= 0 && col < cols) {
                var value = matrix[row][col];
                
                if (value == k) {
                    return true;
                }
                
                if (value < k) {
                    col++;
                } else {
                    row--;
                }
            }

            return false;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public int[][] Matrix { get; set; }
        public int K { get; set; }
        public bool Expected { get; set; }

        public void Verify(bool result) {
            Debug.Assert(result == Expected, $"Test {Id} failed.");
        }
    }
}
