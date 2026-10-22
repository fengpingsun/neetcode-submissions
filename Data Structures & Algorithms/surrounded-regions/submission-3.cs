public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public void Solve(char[][] board) {
        int m = board.Length, n = board[0].Length;
        for (int i = 0; i < m ; i++)
        {
            for (int j = 0; j < n ; j++)
            {
                if (board[i][j] == 'O')
                {
                    BFS(i, j);
                }
            }
        }

        void BFS(int row, int col)
        {
            Queue<(int, int)> queue = new();
            List<(int, int)> regionCells = new();
            queue.Enqueue((row, col));
            board[row][col] = '+';

            bool surrounded = true;
            while (queue.Count > 0)
            {
                (int r, int c) = queue.Dequeue();
                regionCells.Add((r, c));                
                if (surrounded && (r == 0 || r == m - 1 || c == 0 || c == n - 1)) surrounded = false;
                foreach (var dir in directions)
                {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];
                    if (newRow < 0 || newRow >= m || newCol < 0 || newCol >= n
                        || board[newRow][newCol] != 'O')
                        continue;
                    
                    queue.Enqueue((newRow, newCol));
                    board[newRow][newCol] = '+';
                }
            }

            foreach ((int r, int c) in regionCells)
            {
                // Capture or revert
                board[r][c] = surrounded ? 'X' : 'O';
            }
        }
    }
}
