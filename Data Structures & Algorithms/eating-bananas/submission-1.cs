public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // Binary search
        int l = 1, r = piles.Max();
        int ans = r;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (CanEat(m))
            {
                ans = m;
                r = m - 1;
            }
            else l = m + 1;
        }
        return ans;

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
