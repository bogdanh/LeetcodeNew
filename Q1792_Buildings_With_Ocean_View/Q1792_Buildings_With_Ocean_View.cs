using Library;

namespace Q1792_Buildings_With_Ocean_View {

    public class Q1792_Buildings_With_Ocean_View {

        public static void Run() {
            int[] heights = new int[] { 4, 3, 2, 1 };
            int[] result = Solution(heights);
            AssortedMethods.PrintIntArray(result);
        }

        private static int[] Solution(int[] heights) {
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
    }
}
