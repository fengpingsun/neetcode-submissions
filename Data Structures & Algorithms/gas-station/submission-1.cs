public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas = gas.Sum();
        int totalCost = cost.Sum();
        if (totalCost > totalGas) return -1;

        int curBalance = 0;
        int start = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            curBalance += gas[i] - cost[i];
            if (curBalance < 0)
            {
                curBalance = 0; // Reset curBalance to 0
                start = i + 1; // Reset start index to next (i + 1)
                continue;
            }
        }
        return start;
    }
}
