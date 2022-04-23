using System.Text;
using Library;

namespace Q269_Alien_Dictionary {

    public class Q269_Alien_Dictionary {

        public static void Run() {
            // string[] words = new string[] { "wrt", "wrf", "er", "ett", "rftt" };
            // string[] words = new string[] { "ac", "ab", "zc", "zb" };
            string[] words = new string[] { "ac", "ab", "b" };
            string dictionary = Solution(words);
            AssortedMethods.PrintStringArray(words);
            Console.WriteLine(dictionary);
        }

        private static string Solution(string[] words) {
            Dictionary<char, List<char>> adj = new Dictionary<char, List<char>>();
            Dictionary<char, int> count = new Dictionary<char, int>();

            // 1. Initialize adjacent list and inorder count
            foreach (string word in words) {
                foreach (char c in word) {
                    adj[c] = new List<char>();
                    count[c] = 0;
                }
            }

            // 2. Populate adj and inorder
            for (int i = 0; i < words.Length - 1; i++) {
                string word1 = words[i];
                string word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2)) {
                    return string.Empty;
                }

                int j = 0;
                while (j < Math.Min(word1.Length, word2.Length)) {
                    if (word1[j] != word2[j]) {
                        adj[word1[j]].Add(word2[j]);
                        count[word2[j]]++;
                        break;
                    }
                    j++;
                }
            }

            // 3. BFS for topological sort
            Queue<char> q = new Queue<char>();
            StringBuilder dict = new StringBuilder();

            // populate the Queue
            foreach (char c in count.Keys) {
                if (count[c] == 0) {
                    q.Enqueue(c);
                }
            }

            while (q.Count > 0) {
                char c = q.Dequeue();
                dict.Append(c);

                foreach (char next in adj[c]) {
                    count[next]--;

                    if (count[next] == 0) {
                        q.Enqueue(next);
                    }
                }
            }

            if (dict.Length < count.Count) {
                return string.Empty;
            }

            return dict.ToString();
        }
    }
}
