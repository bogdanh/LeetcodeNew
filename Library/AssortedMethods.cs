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

        public static void PrintStringArray(string[] strings) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (string str in strings) {
                sb.Append($"{str}, ");
            }

            if (sb.Length > 1) {
                sb.Length = sb.Length - 2;
            }

            sb.Append("]");

            Console.WriteLine(sb.ToString());
        }

        public static void PrintCharArray(char[] chars) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            string content = string.Join(", ", chars);
            sb.Append(content);

            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }
}