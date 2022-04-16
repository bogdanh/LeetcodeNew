namespace Q1428_Leftmost_Column_With_Least_One {
    public class Q1428_Leftmost_Column_With_Least_One {

        private static int Solution(BinaryMatrix matrix) {
            IList<int> dimensions = matrix.GetDimensions();
            int currRow = 0;
            int currCol = dimensions[1] - 1;

            while (currRow < dimensions[0] && currCol >= 0) {
                if (matrix.Get(currRow, currCol) == 1) {
                    currCol--;
                } else {
                    currRow++;
                }
            }

            return currCol + 1;
        }

        public static void Run() {
            BinaryMatrix matrix = new BinaryMatrix(3, 4);
            matrix.Mat[0] = new int[] { 0, 0, 0, 1 };
            matrix.Mat[1] = new int[] { 0, 0, 1, 1 };
            matrix.Mat[2] = new int[] { 0, 1, 1, 1 };

            int result = Solution(matrix);
            Console.WriteLine(result);
        }
    }

    public class BinaryMatrix {
        private int Rows { get; set; }
        private int Cols { get; set; }
        public int[][] Mat { get; set; }

        public BinaryMatrix(int rows, int cols) {
            Rows = rows;
            Cols = cols;
            Mat = new int[rows][];

            for (int i = 0; i < Rows; i++) {
                Mat[i] = new int[Cols];
            }
        }

        public int Get(int row, int col) {
            if (row < 0 || col == Cols) {
                throw new IndexOutOfRangeException();
            }

            return Mat[row][col];
        }

        public IList<int> GetDimensions() {
            return new List<int> { Rows, Cols };
        }
    }
}
