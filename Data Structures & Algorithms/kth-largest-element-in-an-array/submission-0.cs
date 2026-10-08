public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> queue = new();
        for (int i = 0; i < nums.Length; i++)
        {
            queue.Enqueue(nums[i], nums[i]);
            if (i >= k) queue.Dequeue(); // Pop the smallest item ==> min heap
        }
        return queue.Peek();
    }
}
