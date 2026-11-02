namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>

{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
    }

    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        if (data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        if (data.CompareTo(_tail.Data) >= 0)
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
            return;
        }
        var current = _head.Next;
        while (current != null)
        {
            if (data.CompareTo(current.Data) < 0)
            {
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev!.Next = newNode;
                current.Prev = newNode;
                return;
            }
            current = current.Next;
        }
    }
    public void SortDescending()
    {
        if (_head == null || _head == _tail) return; 

        var current = _head;
        DoubleNode<T>? temp = null;

      
        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev; 
        }

    
        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) // Found
            {
                if (current.Prev == null) // Beginning 
                {
                    current.Next!.Prev = null;
                    _head = _head!.Next;
                    return;
                }
                if (current.Next == null) // End 
                {
                    current.Prev!.Next = null;
                    _tail = _tail!.Prev;
                    return;
                }
                // Middle
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                return;
            }
            current = current.Next;
        }
    }

    public override string ToString()
    {
        if (_head == null) return
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }
}
