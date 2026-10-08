public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (var stone in stones)
        {
            maxHeap.Enqueue(stone, stone);
        }

        while (maxHeap.Count >= 2)
        {
            int stone1 = maxHeap.Dequeue();
            int stone2 = maxHeap.Dequeue();
            int remaining = Math.Abs(stone1 - stone2);
            if (remaining > 0) maxHeap.Enqueue(remaining, remaining);
        }
        return maxHeap.Count == 1? maxHeap.Peek() : 0;
    }
}
