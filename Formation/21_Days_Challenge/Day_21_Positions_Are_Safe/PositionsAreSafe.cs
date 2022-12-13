using Library;

namespace Formation {

    public class PositionsAreSafe {
        public static void Run() {
            var queens = new int[][] {
                new int[] { 0, 0 },
                new int[] { 1, 2 },
                new int[] { 2, 4 }
            };

            var positions = new int[][] {
                new int[] { 3, 1 },
                new int[] { 8, 8 },
                new int[] { 5, 4 }
            };

            var result = Solution(queens, positions);

            AssortedMethods.PrintInt2DArray(result);
        }
        
        private static int[][] Solution(int[][] queens, int[][] positions) {
            var result = new List<int[]>();

            var rows = new HashSet<int>();
            var cols = new HashSet<int>();
            var diag = new HashSet<int>();
            var antiDiag = new HashSet<int>();

            foreach (var queen in queens)
            {
                rows.Add(queen[0]);
                cols.Add(queen[1]);
                diag.Add(queen[0] - queen[1]);
                antiDiag.Add(queen[0] + queen[1]);
            }
            
            foreach (var position in positions) {
                if (rows.Contains(position[0]) ||
                    cols.Contains(position[1]) ||
                    diag.Contains(position[0] - position[1]) ||
                    antiDiag.Contains(position[0] + position[1])) {
                        continue;
                    }

                result.Add(position);
            }
            
            return result.ToArray();
        }
    }
}
