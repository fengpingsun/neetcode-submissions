public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (groupSize == 1) return true;
        if (hand.Length % groupSize != 0) return false;
        
        Array.Sort(hand);
        Queue<(int start, int end)> queue = new();
        queue.Enqueue((hand[0], hand[0]));
        for (int i = 1; i < hand.Length; i++)
        {
            if (queue.Count > 0 && (queue.Peek().end + 1 == hand[i]))
            //if (queue.Peek().end + 1 == hand[i]) // Need to check if queue is empty
            {
                (int s, int e) = queue.Dequeue();
                if ((e + 1) - s + 1 < groupSize)
                {
                    queue.Enqueue((s, hand[i]));
                }
            }
            else
            {
                queue.Enqueue((hand[i], hand[i]));
            }
        }
        return queue.Count == 0;
        // Num  Queue    
        // 1    (1, 1)
        // 2    (1, 2)
        // 2    (1, 2), (2, 2)
        // 3    (2, 2), (1, 3)
        // 3    (1, 3), (2, 3)
        // 4    (2, 3)
        // 4    (2, 4)
        // 5    -
    }
}
