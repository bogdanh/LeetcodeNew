using System;

namespace Q273_Integer_To_English_Words {
    public class Q273_Integer_To_English_Words {
        private static string[] lessThan20 = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fiftheen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] tens = new string[] { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static string Solution(int num) {
            if (num == 0) {
                return "Zero";
            }

            string result = string.Empty;

            Helper(num, ref result);

            return result.Replace(" ", " ").Trim();
        }

        private static void Helper(int num, ref string result) {
            if (num < 20) {
                result += lessThan20[num];
            } else if (num < 100) {
                result += tens[num / 10] + " " + lessThan20[num % 10];
            } else if (num < 1000) {
                Helper(num / 100, ref result);
                result += " Hundred ";
                Helper(num % 100, ref result);
            } else if (num < 1000_000) {
                Helper(num / 1000, ref result);
                result += " Thousand ";
                Helper(num % 1000, ref result);
            } else if (num < 1000_000_000) {
                Helper(num / 1000_000, ref result);
                result += " Million ";
                Helper(num % 1000_000, ref result);
            } else {
                result += lessThan20[num / 1000_000_000] + " Billion ";
                Helper(num % 1000_000_000, ref result);
            }
        }

        public static void Run() {
            int num = 12345;
            Console.WriteLine(num);
            string result = Solution(num);
            Console.WriteLine(result);
        }
    }

}
