using Library;

namespace Formation {

    public class NQueen {
        public static void Run() {
            var n = 8;

            var result = Solution(n);
            
            foreach (var list in result) {
                AssortedMethods.PrintStringArray(list.ToArray(), newLine: true);
                Console.WriteLine();
            }
        }
        
        private static IList<IList<string>> Solution(int n) {
            var matrix = new char[n][];

            for (var i = 0; i < matrix.Length; i++) {
                matrix[i] = Enumerable.Repeat('_', n).ToArray();
            }

            var result = new List<IList<string>>();

            Helper(matrix, 0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), result);

            return result;
        }
        
        private static void Helper(char[][] matrix, int row, HashSet<int> cols, HashSet<int> diagonals, HashSet<int> antiDiagonals, IList<IList<string>> result) {
            if (row == matrix.Length) {
                result.Add(CreateBoard(matrix));
                return;
            }

            for (var col = 0; col < matrix.Length; col++) {
                var currDiagonal = row - col;
                var currAntiDiagonal = row + col;
                
                if (cols.Contains(col) || diagonals.Contains(currDiagonal) || antiDiagonals.Contains(currAntiDiagonal)) {
                    continue;
                }

                cols.Add(col);
                diagonals.Add(currDiagonal);
                antiDiagonals.Add(currAntiDiagonal);
                matrix[row][col] = 'Q';
                Helper(matrix, row + 1, cols, diagonals, antiDiagonals, result);
                cols.Remove(col);
                diagonals.Remove(currDiagonal);
                antiDiagonals.Remove(currAntiDiagonal);
                matrix[row][col] = '_';
            }
        }
        
        private static IList<string> CreateBoard(char[][] matrix) {
            var rows = new List<string>();

            for (var i = 0; i < matrix.Length; i++) {
                var row = new string(matrix[i]);
                rows.Add(row);
            }

            return rows;
        }
    }
}
