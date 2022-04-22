using System.Text;

namespace Library {
    public class AssortedMethods {
        public static void PrintIntArray(int[] arr) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (int elem in arr) {
                sb.Append($"{elem}, ");
            }

            if (sb.Length > 1) {
                sb.Length = sb.Length - 2;
            }

            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }
}