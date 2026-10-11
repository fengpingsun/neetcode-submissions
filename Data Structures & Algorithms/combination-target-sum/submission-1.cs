public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> res = new();
        List<int> combination = new();
        DFS(0, 0);
        return res;

        void DFS(int index, int sum)
        {
            if (sum == target)
            {
                res.Add(new List<int>(combination));
                return;
            }

            if (index == nums.Length || sum > target) return;

            // Include nums[index]
            combination.Add(nums[index]);
            DFS(index, sum + nums[index]);

            // Backtrack
            combination.RemoveAt(combination.Count - 1);

            // Exclude nums[index]
            DFS(index + 1, sum);
        }
    }
}
