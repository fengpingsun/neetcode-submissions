public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);

        List<List<int>> res = new();
        List<int> subset = new();
        DFS(0);
        return res;

        void DFS(int index)
        {
            if (index == nums.Length)
            {
                res.Add(new List<int>(subset));
                return;
            }

            // Include nums[index]
            subset.Add(nums[index]);
            DFS(index + 1);

            // Back track
            subset.RemoveAt(subset.Count - 1);

            // Exclude nums[index]
            while (index + 1 < nums.Length && nums[index + 1] == nums[index]) index++;
            DFS(index + 1);
        }
    }
}
