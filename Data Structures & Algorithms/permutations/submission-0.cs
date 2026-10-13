public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> res = new ();
        List<int> permutation = new();
        bool[] visited = new bool[nums.Length];
        DFS(0);
        return res;

        void DFS(int count)
        {
            if (count == nums.Length)
            {
                res.Add(new List<int>(permutation));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (visited[i]) continue;

                // Add current number to permutation
                visited[i] = true;
                permutation.Add(nums[i]);
                DFS(permutation.Count);

                // Back tracking
                visited[i] = false;
                permutation.RemoveAt(permutation.Count - 1);
            }
        }
    }
}
