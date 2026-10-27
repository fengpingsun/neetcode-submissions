public class Solution {
    public int MaxSubArray(int[] nums) {
        int res = nums[0];
        int curSum = 0;
        foreach (var num in nums)
        {
            curSum = Math.Max(num, curSum + num);
            res = Math.Max(curSum, res);
        }
        return res;
    }
}
