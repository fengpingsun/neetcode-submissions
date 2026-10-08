public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[right] > nums[mid])
                // Minimum is in the left half
                right = mid;
            else
                // Minimum is in the left half or at mid
                left = mid + 1;
        }

        return nums[left];
    }
}
