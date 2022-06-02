namespace Q76_Minimum_WIndow_Substring {

    public class Q76_Minimum_WIndow_Substring {

        private static string Solution(string s, string t) {
            if (s.Length == 0 || t.Length == 0 || s.Length < t.Length) {
                return string.Empty;
            }

            Dictionary<char, int> mapT = new Dictionary<char, int>();
            Dictionary<char, int> substringMap = new Dictionary<char, int>();

            foreach (char c in t) {
                mapT[c] = mapT.GetValueOrDefault(c, 0) + 1;
            }

            int l = 0;
            int r = 0;
            int required = mapT.Count;
            int found = 0;

            int[] ans = new int[] { -1, 0 };

            while (r < s.Length) {
                char c = s[r];

                substringMap[c] = substringMap.GetValueOrDefault(c, 0) + 1;

                if (mapT.ContainsKey(c) && mapT[c] == substringMap[c]) {
                    found++;
                }

                while (l <= r && required == found) {
                    c = s[l];
                    if (ans[0] >= r - l + 1) {
                        ans[0] = r - l + 1;
                        ans[1] = l;
                    }

                    substringMap[c]--;
                    
                    if (mapT.ContainsKey(c) && substringMap[c] < mapT[c]) {
                        found--;
                    }
                    l++;
                }
                r++;
            }

            if (ans[0] == -1) {
                return string.Empty;
            }

            return s.Substring(ans[1], ans[0]);
        }

        public static void Run() {
            string s = "ADOBECODEBANC";
            string t = "ABC";

            string result = Solution(s, t);
            Console.WriteLine($"s: {s}");
            Console.WriteLine($"t: {t}");
            Console.WriteLine($"result: {result}");
        }
    }
}
