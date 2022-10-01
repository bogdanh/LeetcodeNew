#nullable disable warnings
using System.Diagnostics;
using Library;

namespace Formation {

    public class SpiralTraversal {
        public static void Run() {
            var test = new Test {
                Id = 1,
                InputMatrix = new int[4][] {
                            new int[] { 1, 2, 3, 4 },
                            new int[] { 5, 6, 7, 8 },
                            new int[] { 9, 10, 11, 12 },
                            new int[] { 13, 14, 15, 16 }
                },
                Expected = new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 }
            };

            AssortedMethods.PrintInt2DArray(test.InputMatrix);

            var result = Solution(test.InputMatrix);
            AssortedMethods.PrintIntArray(result);
            test.Verify(result);
        }

        private static int[] Solution(int[][] matrix) {
            var result = new int[matrix.Length * matrix[0].Length];
            var rStart = 0;
            var rEnd = matrix.Length - 1;
            var cStart = 0;
            var cEnd = matrix[0].Length - 1;
            
            var direction = 0; // 0: right; 1: down; 2 = left; 3 = up
            var idx = 0;

            while (idx < result.Length) {
                
                switch (direction) {
                    case 0: // left to right
                        for (var i = cStart; i <= cEnd; i++) {
                            result[idx++] = matrix[rStart][i];
                        }
                        rStart++;
                        break;
                    case 1:
                        for (var i = rStart; i <= rEnd; i++) {
                            result[idx++] = matrix[i][cEnd];
                        }
                        cEnd--;
                        break;
                    case 2:
                        for (var i = cEnd; i >= cStart; i--) {
                            result[idx++] = matrix[rEnd][i];
                        }
                        rEnd--;
                        break;
                    case 3:
                        for (var i = rEnd; i >= rStart; i--) {
                            result[idx++] = matrix[i][cStart];
                        }
                        cStart++;
                        break;
                }

                direction = (direction + 1) % 4;
            }

            return result;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public int[][] InputMatrix { get; set; }
        public int[] Expected { get; set; }
        
        public void Verify(int[] result) {
            Debug.Assert(Enumerable.SequenceEqual(result, Expected), $"Test {Id} failed.");
        }
    }
}
