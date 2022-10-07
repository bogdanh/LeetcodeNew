#nullable disable warnings
using System.Diagnostics;
using Library;

namespace Formation {

    public class ToeplitzMatrix {
        public static void Run() {
            var test = new Test {
                Id = 1,
                Matrix = new int[4][] {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 1, 2, 3 },
                    new int[] { 6, 5, 1, 2 },
                    new int[] { 7, 6, 5, 1 }
                },
                Expected = true
            };

            AssortedMethods.PrintInt2DArray(test.Matrix);
            var result = IsToeplitzMatrix(test.Matrix);
            test.Verify(result);
        }

        private static bool IsToeplitzMatrix(int[][] matrix) {
            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[i].Length; j++) {
                    var val = matrix[i][j];
                    
                    if (i > 0 && j > 0 && val != matrix[i - 1][j - 1]) {
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
