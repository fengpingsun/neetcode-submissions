public class WordDictionary {
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new();
        public bool IsEndOfWord;
    }

    private TrieNode root;
    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode curr = root;
        foreach (char c in word)
        {
            if (!curr.Children.ContainsKey(c)) curr.Children[c] = new TrieNode();
            curr = curr.Children[c];
        }
        curr.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        return DFS(root, 0);

        bool DFS(TrieNode node, int index)
        {
            if (index == word.Length) return node.IsEndOfWord;
            
            char c = word[index];
            if (c != '.')
            {
                if (!node.Children.ContainsKey(c)) return false;
                return DFS(node.Children[c], index + 1);
            }
            else
            {
                foreach (var child in node.Children.Values)
                {
                    if (DFS(child, index + 1))
                        return true;
                }
                return false;
            }
        }
    }

    
}
