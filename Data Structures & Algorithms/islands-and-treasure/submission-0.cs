public class Solution {
    int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public void islandsAndTreasure(int[][] grid) {
        Queue<(int, int)> queue = new();
        int m = grid.Length, n = grid[0].Length;
        int remainings = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    queue.Enqueue((i, j));
                }
                else if (grid[i][j] == int.MaxValue)
                {
                    remainings++;
                }
            }
        }

        int distance = 0;
        while (queue.Count > 0 && remainings > 0)
        {
            int count = queue.Count;
            distance++;
            for (int i = 0; i < count; i++)
            {
                (int row, int col) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];
                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n
                        && grid[newRow][newCol] == int.MaxValue)
                    {
                        grid[newRow][newCol] = distance;
                        queue.Enqueue((newRow, newCol));
                        remainings--;
                    }
                }
            }
        }
    }
}
