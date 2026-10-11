public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new();
        List<int> subset = new();
        DFS(0);
        return res;

        void DFS(int index)
        {
            if (index == nums.Length)
            {
                // If not create a new list, then backtracking would modify previously stored results 
                res.Add(new List<int>(subset));
                return;
            }

            // Exclude nums[index]
            DFS(index + 1);

            // Include nums[index]
            subset.Add(nums[index]);    
            DFS(index + 1);

            // Backtrack
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
