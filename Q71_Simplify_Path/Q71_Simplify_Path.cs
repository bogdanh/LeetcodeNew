using System.Text;

namespace Q71_Simplify_Path {
    public class Q71_Simplify_Path {
        
        private static string? Solution(string path) {
            if (string.IsNullOrEmpty(path)) {
                return null;
            }

            LinkedList<string> list = new LinkedList<string>();
            string[] parts = path.Split("/");
            
            foreach (string part in parts) {
                if (part.Equals(".") || string.IsNullOrEmpty(part)) {
                    continue;
                }
                
                if (part.Equals("..")) {
                    if (list.Count > 0) {
                        list.RemoveLast();
                    }
                } else {
                    list.AddLast(part);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("/");
            
            foreach (string part in list) {
                sb.Append($"{part}/");
            }
            
            if (sb.Length > 1) {
                sb.Length = sb.Length - 1;
            }

            return sb.ToString();
        }
        
        public static void Run() {
            string path = "/../home/level1/level2/./level3/..";
            // "/home//level1/./level2/level3/../"; // "/home/level1/level2"
            Console.WriteLine(path);
            string? result = Solution(path);
            Console.WriteLine(result);
        }
    }
}
