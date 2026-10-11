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
                res.Add(new List<int>(subset));
                return;
            }

            DFS(index + 1);
            subset.Add(nums[index]);
            DFS(index + 1);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
