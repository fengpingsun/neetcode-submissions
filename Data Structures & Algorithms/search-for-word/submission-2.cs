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
            // Current cell doesn't match the expected character
            if (board[row][col] != word[charIndex])
                return false;

            // Found the entire word
            if (charIndex == word.Length - 1)
                return true;

            // mark the current cell as visited
            visited[row, col] = true;

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                if (newRow < 0 || newRow >= m
                    || newCol < 0 || newCol >= n
                    || visited[newRow, newCol])
                    continue;

                if (DFS(newRow, newCol, charIndex + 1))
                    return true;
            }

            // Back track
            visited[row, col] = false;
            return false;
        }
    }
}
