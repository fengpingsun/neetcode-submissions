public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);

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

            // Pruning invalid branches
            if (index == candidates.Length || sum > target) return;

            // Include nums[index]
            combination.Add(candidates[index]);
            DFS(index + 1, sum + candidates[index]);

            // Backtrack
            combination.RemoveAt(combination.Count - 1);

            // Exclude nums[index]
            while (index + 1 < candidates.Length && candidates[index + 1] == candidates[index]) index++; // Avoid duplicates
            DFS(index + 1, sum);
        }
    }
}
