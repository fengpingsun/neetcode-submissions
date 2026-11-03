public class Solution {
    public int Jump(int[] nums) {
        int left = 0, right = 0, maxReach = 0;
        int steps = 0;
        while (right < nums.Length - 1)
        {
            steps++;
            for (int i = left; i <= right; i++)
            {
                maxReach = Math.Max(maxReach, i + nums[i]);
            }
            left = right + 1;
            right = maxReach;
        }
        return steps;
    }
}
