namespace Formation {

    public class MazeSolver {
        public static void Run() {
            var result = new List<(int, int)>();
            var currPath = new Stack<(int, int)>();

            var matrix = new char[9][] {
                new char[] { 'H', 'H', 'H', '_', '_', 'H', 'H', 'H', 'G' },
                new char[] { 'H', '_', 'H', '_', '_', 'H', '_', '_', '_' },
                new char[] { 'H', '_', 'H', 'H', '_', 'H', '_', 'H', 'H' },
                new char[] { '_', '_', '_', 'H', '_', 'H', '_', 'H', '_' },
                new char[] { 'H', 'H', 'H', 'H', '_', 'H', '_', 'H', '_' },
                new char[] { 'H', '_', '_', 'H', '_', 'H', '_', 'H', 'H' },
                new char[] { 'H', 'H', '_', '_', '_', 'H', 'H', 'H', '_' },
                new char[] { 'H', '_', 'H', 'H', 'H', 'H', '_', '_', 'H' },
                new char[] { 'H', 'H', 'H', '_', '_', 'H', 'H', 'H', 'H' }
            };

            var visited = new bool[9][] {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            };

            Solution(matrix, result, currPath, 0, 0, visited);

            Console.WriteLine();
            
            foreach (var coord in result) {
                Console.Write($"({coord.Item1}, {coord.Item2})");
            }

            Console.WriteLine();
        }
        
        private static void Solution(char[][] matrix, List<(int, int)> result, Stack<(int, int)> currPath, int i, int j, bool[][] visited) {
            if (i < 0 || 
                i == matrix.Length || 
                j < 0 || 
                j == matrix[i].Length || 
                visited[i][j] || 
                result.Count > 0 || 
                matrix[i][j] == '_') {
                return;
            }
            
            if (matrix[i][j] == 'G') {
                var path = currPath.ToList();
                path.Reverse();
                result.AddRange(path);
                return;
            }

            visited[i][j] = true;
            currPath.Push((i, j));

            Solution(matrix, result, currPath, i - 1, j, visited);
            Solution(matrix, result, currPath, i + 1, j, visited);
            Solution(matrix, result, currPath, i, j - 1, visited);
            Solution(matrix, result, currPath, i, j + 1, visited);

            currPath.Pop();
            visited[i][j] = false;
        }
    }
}
