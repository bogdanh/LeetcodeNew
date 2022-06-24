#nullable disable warnings
public class TrieNode {
    public Dictionary<char, TrieNode> Children{ get; set; }
    public bool IsEnd { get; set; }
    
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
    }
}