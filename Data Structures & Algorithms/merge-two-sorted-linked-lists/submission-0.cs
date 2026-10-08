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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode();
        ListNode cur = dummy;
        ListNode p1 = list1, p2 = list2;
        while (p1 != null && p2 != null)
        {
            if (p1.val <= p2.val)
            {
                cur.next = p1;
                p1 = p1.next;
            }
            else
            {
                cur.next = p2;
                p2 = p2.next;
            }
            cur = cur.next;
        }
        if (p1 != null) cur.next = p1;
        if (p2 != null) cur.next = p2;
        return dummy.next;
    }
}