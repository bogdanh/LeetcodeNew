using Library;

namespace Q1792_Buildings_With_Ocean_View {

    public class Q1792_Buildings_With_Ocean_View {

        public static void Run() {
            int[] heights = new int[] { 4, 2, 3, 1 };
            int[] result = Solution_Right_To_Left(heights);
            AssortedMethods.PrintIntArray(result);
            result = Solution_Left_To_Right(heights);
            AssortedMethods.PrintIntArray(result);
        }

        private static int[] Solution_Right_To_Left(int[] heights) {
            int max = int.MinValue;
            Stack<int> stack = new Stack<int>();

            for (int i = heights.Length - 1; i >= 0; i--) {
                if (heights[i] > max) {
                    max = heights[i];
                    stack.Push(i);
                }
            }

            int[] result = new int[stack.Count];
            int idx = 0;
            while (stack.Count > 0) {
                result[idx++] = stack.Pop();
            }

            return result;
        }

        private static int[] Solution_Left_To_Right(int[] heights) {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < heights.Length; i++) {
                while (stack.Count > 0 && heights[i] >= heights[stack.Peek()]) {
                    stack.Pop();
                }

                stack.Push(i);
            }

            int[] result = new int[stack.Count];

            for (int i = result.Length - 1; i >= 0; i--) {
                result[i] = stack.Pop();
            }

            return result;
        }
    }
}
