using System.Text;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null!;
    }
}


public class Linkedlist
{
    private ListNode? _head;


    public void Createloop(Linkedlist ls, int pos)
    {
        if (_head == null) return;
        ListNode? lastNode = _head;
        ListNode? current = _head;
        while (lastNode!.next != null)
        {
            lastNode = lastNode.next;
        }
        for (int i = 0; i < pos; i++)
        {
            current = current!.next;
        }
        lastNode.next = current!;
        //ls._head.next.next.next.next = ls._head;
    }
       
    public void AddToHead(int data)
    {
        // Check if _head have some value
        // if not then we will set new node as head
        var newNode = new ListNode(data);
        if (_head == null)
        {
            _head = newNode;
            return;
        }
        newNode.next = _head;
        _head = newNode;
    }

    /* Inserts a new Node at front of the list. */
    public void push(int new_data)
    {
        /* 1 & 2: Allocate the Node &
                Put in the data*/
        ListNode new_node = new ListNode(new_data);

        /* 3. Make next of new Node as head */
        new_node.next = _head!;

        /* 4. Move the head to point to new Node */
        _head = new_node;
    }

    public ListNode GetListNode()
    {
        return _head!;
    }

    public string Print()
    {
        ListNode? current = _head;
        var builder = new StringBuilder();
        while (current != null)
        {
            builder.Append(current.val + "->");
            current = current.next;
        }
        return builder.ToString();
    }
}



public class Solution
{
    // Floyd's Tortoise and Hare Algorithm
    public bool HasCycle(ListNode head)
    {
        if (head == null) return false;

        var slow = head;
        var fast = head.next;

        while (slow != fast)
        {
            if (fast == null || fast.next == null)
            {
                return false;
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        return true;
    }

    // Returns true if there is a loop in linked
    // list else returns false.
    public static bool detectLoop(ListNode h)
    {
        HashSet<ListNode> s = new HashSet<ListNode>();
        while (h != null)
        {
            // If we have already has this node
            // in hashmap it means their is a cycle
            // (Because you we encountering the
            // node second time).
            if (s.Contains(h))
                return true;

            // If we are seeing the node for
            // the first time, insert it in hash
            s.Add(h);

            h = h.next;
        }

        return false;
    }

    public static void Main()
    {
        //3,2,0,-4
        var list = new Linkedlist();
        list.AddToHead(50);
        list.AddToHead(40);
        list.AddToHead(30);
        list.AddToHead(20);
        list.AddToHead(10);

        Console.WriteLine(list.Print());

        /*Create loop for testing @ pos 1 */
        list.Createloop(list, 1);


        Solution s = new Solution();
        Console.WriteLine(s.HasCycle(list.GetListNode()));

        if (detectLoop(list.GetListNode()))
            Console.WriteLine("Loop found");
        else
            Console.WriteLine("No Loop");
    }
}


