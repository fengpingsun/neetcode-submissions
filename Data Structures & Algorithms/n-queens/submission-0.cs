public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        List<List<string>> res = new();
        List<string> queens = new();
        string s = new string('.', n);
        bool[] rows = new bool[n];
        bool[] cols = new bool[n];
        bool[] diag1 = new bool[n * 2 - 1];
        bool[] diag2 = new bool[n * 2 - 1];
        DFS(0);
        return res;

        void DFS(int row)
        {
            if (row == n)
            {
                res.Add(new List<string>(queens));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n - 1;
                int d2 = row + col; 
                if (rows[row] || cols[col] || diag1[d1] || diag2[d2]) continue;

                // Place queen
                queens.Add(CreateQueenString(col));
                rows[row] = true;
                cols[col] = true;
                diag1[d1] = true;
                diag2[d2] = true;

                DFS(row + 1);

                // Backtrack
                queens.RemoveAt(queens.Count - 1);
                rows[row] = false;
                cols[col] = false;
                diag1[d1] = false;
                diag2[d2] = false;
            }
        }

        string CreateQueenString(int col)
        {
            char[] arr = s.ToCharArray();
            arr[col] = 'Q';
            return new string(arr);
        }
    }
}
