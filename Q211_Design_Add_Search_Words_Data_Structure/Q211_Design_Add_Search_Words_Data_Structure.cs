#nullable disable warnings
namespace Q211_Design_Add_Search_Words_Data_Structure {

    public class Q211_Design_Add_Search_Words_Data_Structure {
        public static void Run() {
            WordDictionary wordDict = new WordDictionary();
            wordDict.AddWord("bad");
            wordDict.AddWord("dad");
            wordDict.AddWord("mad");

            var result = wordDict.Search("pad");
            Console.WriteLine($"pad: {result}");

            // result = wordDict.Search("bad");
            // Console.WriteLine($"bad: {result}");

            // result = wordDict.Search(".ad");
            // Console.WriteLine($".ad: {result}");

            result = wordDict.Search("b..");
            Console.WriteLine($"b..: {result}");
        }
    }
    
    internal class WordDictionary {
        public TrieNode Trie { get; set; }
        
        public WordDictionary() {
            Trie = new TrieNode();
        }
        
        public void AddWord(string word) {
            TrieNode node = Trie;
            
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c)) {
                    node.Children[c] = new TrieNode();
                }

                node = node.Children[c];
            }

            node.IsEnd = true;
        }
        
        public bool Search(string word) {
            return Search(word, Trie);
        }
        
        private bool Search(string word, TrieNode node) {
            for (int i = 0; i < word.Length; i++) {
                char c = word[i];
                
                if (node.Children.ContainsKey(c)) {
                    node = node.Children[c];
                } else {
                    if (c == '.') {
                        foreach (char x in node.Children.Keys) {
                            TrieNode child = node.Children[x];
                            if (Search(word.Substring(i + 1), child)) {
                                return true;
                            }
                        }
                    }

                    return false;
                }
            }

            return node.IsEnd;
        }
    }
}
