public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public void Solve(char[][] board) {
        int m = board.Length, n = board[0].Length;
        Queue<(int, int)> queue = new();
        for (int i = 0; i < m; i++)
        {
            MarkAndEnqueue(i, 0); // First column
            MarkAndEnqueue(i, n - 1); // Last column
        }

        for (int j = 0; j < n; j++)
        {
            MarkAndEnqueue(0, j); // First row
            MarkAndEnqueue(m - 1, j); // Last row
        }

        // Border-first BFS: capture unsurrounded regions and convert them to U
        while (queue.Count > 0)
        {
            (int row, int col) = queue.Dequeue();
            foreach (int[] dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n
                    && board[newRow][newCol] == 'O')
                {
                    board[newRow][newCol] = 'U';
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        // Capture or preserve
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
                else if (board[i][j] == 'U')
                {
                    board[i][j] = 'O';
                }
            }
        }

        void MarkAndEnqueue(int i, int j)
        {
            if (board[i][j] == 'O')
            {
                board[i][j] = 'U';
                queue.Enqueue((i, j));
            }
        }
    }
}
