public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public void Solve(char[][] board) {
        int m = board.Length, n = board[0].Length;
        List<(int, int)> regionCells = new();
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (board[i][j] == 'O')
                {
                    regionCells.Clear();
                    DFS(i, j);
                    Capture();
                }
            }
        }

        void DFS(int row, int col)
        {
            if (row < 0 || row >= m || col < 0 || col >= n
                || board[row][col] != 'O')
                return;
            
            board[row][col] = '+';
            regionCells.Add((row, col));
            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                DFS(newRow, newCol);
            }
        }

        void Capture()
        {
            bool surrounded = true;
            foreach ((int row, int col) in regionCells)
            {
                if (row == 0 || row == m - 1 || col == 0 || col == n - 1) // if edge cell
                {
                    surrounded = false;
                    break;
                }
            }

            foreach ((int row, int col) in regionCells)
            {
                // Capture or revert
                board[row][col] = surrounded ? 'X' : 'O';
            }
        }
    }
}
