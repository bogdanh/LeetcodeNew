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

        public static void PrintInt2DArray(int[][] arr) {
            StringBuilder sb = new StringBuilder();

            foreach (int[] a in arr) {
                sb.Append("[");
                sb.Append(string.Join(", ", a));
                sb.AppendLine("]");
            }
            
            Console.WriteLine(sb.ToString());
        }
        
        public static void PrintChar2DArray(char[][] arr) {
            StringBuilder sb = new StringBuilder();
            
            foreach (char[] a in arr) {
                sb.Append("[");
                sb.Append(string.Join(", ", a));
                sb.AppendLine("]");
            }

            Console.WriteLine(sb.ToString());
        }

        public static void PrintStringArray(string[] strings, bool? newLine = false) {
            StringBuilder sb = new StringBuilder();
            
            if (!newLine.GetValueOrDefault(false)) {
                sb.Append("[");
            }

            foreach (string str in strings) {
                _ = newLine.GetValueOrDefault(false) ? sb.AppendLine($"{str}, ") : sb.Append($"{str}, ");
            }

            if (sb.Length > 1) {
                sb.Length = sb.Length - 2;
            }

            if (!newLine.GetValueOrDefault(false)) {
                sb.Append("]");
            }

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