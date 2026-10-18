public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];

    public int NumIslands(char[][] grid) {
        int res = 0;
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == '1')
                {
                    DFS(i, j);
                    res++;
                }
            }
        }
        return res;
        
        void DFS(int row, int col)
        {
            // Prune invalid branches
            if (row < 0 || row >= m || col < 0 || col >= n || visited[row, col] || grid[row][col] == '0') return;

            // Visit current cell
            visited[row, col] = true;
            foreach (var dir in directions)
            {
                DFS(row + dir[0], col + dir[1]);
            }
        }
    }
}
