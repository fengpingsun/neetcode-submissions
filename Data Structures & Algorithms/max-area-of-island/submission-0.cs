public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public int MaxAreaOfIsland(int[][] grid) {
        int res = 0;
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    int area = DFS(i, j);
                    res = Math.Max(res, area);
                }
            }
        }
        return res;

        int DFS(int row, int col)
        {
            // Prune invalid branches
            if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == 0) return 0;

            // Visit current cell
            int count = 1;
            grid[row][col] = 0;
            foreach (var dir in directions)
            {
                count += DFS(row + dir[0], col + dir[1]);
            }
            return count;
        }
    }
}
