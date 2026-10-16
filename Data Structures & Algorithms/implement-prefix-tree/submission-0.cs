public class PrefixTree {
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new();
        public bool IsEndOfWord;
    }

    private TrieNode root;
    public PrefixTree() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode curr = root;
        foreach (char c in word)
        {
            if (!curr.Children.ContainsKey(c)) curr.Children[c] = new TrieNode();
            curr = curr.Children[c];
        }
        curr.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        TrieNode curr = root;
        foreach (char c in word)
        {
            if (!curr.Children.ContainsKey(c)) return false;
            curr = curr.Children[c];
        }
        return curr.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode curr = root;
        foreach (char c in prefix)
        {
            if (!curr.Children.ContainsKey(c)) return false;
            curr = curr.Children[c];
        }
        return true;
    }
}
