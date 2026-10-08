public class Node
{
    public (int Key, int Val) Value { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }
    public Node((int Key, int Val) val, Node previous = null, Node next = null)
    {
        Value = val;
        Previous = previous;
        Next = next;
    }
}

public class MyLinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }
    public Node Last{ get { return Tail.Previous; } }

    public MyLinkedList()
    {
        Head = new Node((0, 0));
        Tail = new Node((0, 0));
        Head.Next = Tail;
        Tail.Previous = Head;
    }

    public void AddFirst(Node node)
    {
        Node first = Head.Next;
        node.Next = first;
        Head.Next = node;
        first.Previous = node;
        node.Previous = Head;
    }

    public void Remove(Node node)
    {
        Node previous = node.Previous;
        Node next = node.Next;
        previous.Next = next;
        next.Previous = previous;
    }
}

public class LRUCache {
    MyLinkedList list = new();
    Dictionary<int, Node> cache = new();
    int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;    
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;
        var node = cache[key];
        list.Remove(node);
        list.AddFirst(node);
        return node.Value.Val;
    }
    
    public void Put(int key, int value) {
        Node node = null;
        if (cache.ContainsKey(key))
        {
            node = cache[key];
            list.Remove(node);
            node.Value = (key, value);
        }
        else
        {
            node = new Node((key, value));
            if (cache.Count == capacity)
            {
                var nodeToBeRemoved = list.Last;
                list.Remove(nodeToBeRemoved);
                cache.Remove(nodeToBeRemoved.Value.Key);
            }
            cache[key] = node;
        }
        list.AddFirst(node);
    }
}
