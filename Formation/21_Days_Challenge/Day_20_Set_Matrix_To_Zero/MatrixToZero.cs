using Library;

namespace Formation {

    public class MatrixToZero {
        public static void Run() {
            var matrix = new int[][] {
                new int[] { 0, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 0 }
            };

            AssortedMethods.PrintInt2DArray(matrix);

            var result = Solution(matrix);

            AssortedMethods.PrintInt2DArray(matrix);
        }

        private static int[][] Solution(int[][] matrix) {
            var firstRow = false;
            var firstCol = false;
            
            if (matrix.Length == 0) {
                return matrix;
            }

            for (var i = 0; i < matrix.Length; i++) {
                if (matrix[i][0] == 0) {
                    firstCol = true;
                    break;
                }
            }

            for (var i = 0; i < matrix[0].Length; i++) {
                if (matrix[0][i] == 0) {
                    firstRow = true;
                    break;
                }
            }

            for (var i = 1; i < matrix.Length; i++) {
                for (var j = 1; j < matrix[i].Length; j++) {
                    if (matrix[i][j] == 0) {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (var i = 1; i < matrix.Length; i++) {
                for (var j = 1; j < matrix[i].Length; j++) {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                        matrix[i][j] = 0;
                    }
                }
            }
            
            if (firstRow) {
                for (var i = 0; i < matrix[0].Length; i++) {
                    matrix[0][i] = 0;
                }
            }
            
            if (firstCol) {
                for (var i = 0; i < matrix.Length; i++) {
                    matrix[i][0] = 0;
                }
            }

            return matrix;
        }
    }
}
