public class Solution {
    class PrefixNode
    {
        public Dictionary<char, PrefixNode> Children = new();
        public bool IsEndOfWord;
    }

    private int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    private int[,] directions2 = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
    private PrefixNode root = new PrefixNode();
    public void AddWord(string word)
    {
        PrefixNode curr = root;
        foreach (char c in word)
        {
            if (!curr.Children.ContainsKey(c)) curr.Children[c] = new PrefixNode();
            curr = curr.Children[c];
        }
        curr.IsEndOfWord = true;
    }

    public List<string> FindWords(char[][] board, string[] words) {
        foreach (var s in words) AddWord(s);     

        List<string> res = new();
        int m = board.Length, n = board[0].Length;
        bool[,] visited = new bool[m, n];
        StringBuilder word = new();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                DFS(i, j, root);
            }
        }
        return res;

        void DFS(int row, int col, PrefixNode node)
        {
            // Prune invalid branches
            if (row < 0 || row >= m || col < 0 || col >= n || visited[row, col]) return;

            char c = board[row][col];
            if (!node.Children.ContainsKey(c)) return;

            // Visit current cell
            node = node.Children[c];
            visited[row, col] = true;
            word.Append(c);
            if (node.IsEndOfWord)
            {
                res.Add(word.ToString());
                node.IsEndOfWord = false; // Without this line, it will cause duplicate results
                //return;
            }

            // Go four directions
            for (int i = 0; i < directions2.GetLength(0); i++)
            {
                int newRow = row + directions2[i, 0];
                int newCol = col + directions2[i, 1];
                DFS(newRow, newCol, node);
            }

            // Backtrack
            visited[row, col] = false;
            word.Length -= 1;
        }
    }
}
