public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        Queue<(int, int)> queue = new();
        int freshes = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue((i, j));
                }
                else if (grid[i][j] == 1)
                {
                    freshes++;
                }
            }
        }

        int res = 0;
        while (queue.Count > 0 && freshes > 0)
        {
            int count = queue.Count;
            res++;
            for (int i = 0; i < count; i++)
            {
                (int row, int col) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];
                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n
                        && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2;
                        freshes--;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
        }

        return freshes == 0 ? res : -1;
    }
}
