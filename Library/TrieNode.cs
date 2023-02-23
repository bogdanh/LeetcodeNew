#nullable disable warnings
using System.Diagnostics;

[DebuggerDisplay("{CurrentChar}")]
public class TrieNode {
    public char CurrentChar { get; set; }
    public Dictionary<char, TrieNode> Children{ get; set; }
    public bool IsEnd { get; set; }
    
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
        IsEnd = false;
        CurrentChar = '\0';
    }
}