public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // MaxHeap
        PriorityQueue<int[], int> maxHeap = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach(var point in points)
        {
            int val = point[0] * point[0] + point[1] * point[1];
            maxHeap.Enqueue(point, val);
            if (maxHeap.Count > k) maxHeap.Dequeue(); // Pop the largest element
        }

        int[][] res = new int[k][];
        for (int i = k - 1; i >= 0; i--)
        {
            res[i] = maxHeap.Dequeue();
        }
        return res;
    }
}
