public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rows = matrix.Length, cols = matrix[0].Length;
        int l = 0, r = rows * cols - 1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            int val = matrix[m / cols][m % cols];
            if (val == target) return true;
            if (val > target) r = m - 1;
            else l = m + 1;
        }
        return false;
    }
}
