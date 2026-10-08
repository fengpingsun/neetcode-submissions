/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        if (intervals == null || intervals.Count == 0) return 0;

        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        foreach (Interval interval in intervals)
        {
            if (queue.Count > 0 && queue.Peek() <= interval.start)
                queue.Dequeue(); // Meeting reuse
            queue.Enqueue(interval.end, interval.end);
        }
        return queue.Count;
    }
}
