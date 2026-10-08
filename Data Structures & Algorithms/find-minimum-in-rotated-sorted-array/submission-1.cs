public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
                // Minimum is in the right half
                left = mid + 1;
            else
                // Minimum is in the left half or at mid
                right = mid;
        }

        return nums[left];
    }
}
