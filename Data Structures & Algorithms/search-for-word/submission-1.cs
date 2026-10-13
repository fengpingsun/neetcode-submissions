public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length, n = board[0].Length;
        bool[,] visited = new bool[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (DFS(i, j, 0)) return true;
            }
        }
        return false;

        bool DFS(int row, int col, int charIndex)
        {
            if (row < 0 || row >= m
                || col < 0 || col >= n
                || visited[row, col]
                || board[row][col] != word[charIndex])
                return false;

            if (charIndex == word.Length - 1) return true;
            visited[row, col] = true;
            bool res = DFS(row - 1, col, charIndex + 1)
                            || DFS(row + 1, col, charIndex + 1)
                            || DFS(row, col - 1, charIndex + 1)
                            || DFS(row, col + 1, charIndex + 1);
            visited[row, col] = false; // Back track
            return res;
        }
    }
}
