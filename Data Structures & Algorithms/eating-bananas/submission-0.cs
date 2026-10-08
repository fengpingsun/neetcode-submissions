public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        if (piles.Length > h) throw new Exception();

        // Binary search
        int l = 1, r = piles.Max();
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (CanEat(m)) r = m - 1;
            else l = m + 1;
        }
        return l;

        bool CanEat(int speed)
        {
            int res = 0;
            foreach (var pile in piles)
            {
                res += (pile + speed - 1) / speed;
            }
            return res <= h;
        }
    }
}
