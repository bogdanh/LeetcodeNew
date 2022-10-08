#nullable disable warnings
using System.Diagnostics;
using Library;

namespace Formation {

    public class MonotonicMatrix {
        public static void Run() {
            var test = new Test {
                Id = 1,
                Matrix = new int[3][] {
                    new int[] { 0, 0, 0, 1 },
                    new int[] { 1, 1, 1, 2 },
                    new int[] { 2, 3, 4, 5 }
                },
                Expected = true
            };

            AssortedMethods.PrintInt2DArray(test.Matrix);

            var result = Solution(test.Matrix);

            test.Verify(result);
        }
        
        private static bool Solution(int[][] matrix) {
            for (var i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[i].Length; j++) {
                    if (i > 0 && matrix[i][j] < matrix[i - 1][j]) {
                        return false;
                    }
                    
                    if (j > 0 && matrix[i][j] < matrix[i][j - 1]) {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    internal class Test {
        public int Id { get; set; }
        public int[][] Matrix { get; set; }
        public bool Expected { get; set; }
        
        public void Verify(bool result) {
            Debug.Assert(result == Expected, $"Test {Id} failed.");
        }
    }
}
