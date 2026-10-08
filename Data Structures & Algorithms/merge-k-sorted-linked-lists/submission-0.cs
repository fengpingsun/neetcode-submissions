/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {    
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) return null;
        
        ListNode[] res = lists;
        while (res.Length != 1)
        {
            var tmpList = new ListNode[(res.Length + 1) / 2];
            for (int i = 0; i < res.Length; i += 2)
            {
                ListNode list1 = res[i];
                ListNode list2 = i == res.Length - 1 ? null : res[i + 1];
                tmpList[i / 2] = MergeTwoLists(list1, list2);
            }
            res = tmpList;
        }
        return res[0];

        ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode dummy = new();
            ListNode curr = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            if (l1 != null) curr.next = l1;
            if (l2 != null) curr.next = l2;
            return dummy.next;
        }
    }
}
