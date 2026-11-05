public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (groupSize == 1) return true;
        if (hand.Length % groupSize != 0) return false;

        Array.Sort(hand);
        Queue<(int start, int end)> queue = new();
        foreach (int card in hand)
        {
            if (queue.Count > 0)
            {
                var (start, end) = queue.Peek();
                if (end + 1 < card) // Early exit: the expected card has already been skipped
                    return false;
                
                if (end + 1 == card)
                {
                    queue.Dequeue();
                    if ((end + 1) - start + 1 < groupSize)
                        queue.Enqueue((start, card));
                    
                    continue;
                }
            }

            // Start a new group
            queue.Enqueue((card, card));
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
