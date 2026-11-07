using System.Linq;
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

    public DoubleNode<T>? Get_tail1()
    {
        return _tail;
    }

   // Add 
    public void Add(T data, DoubleNode<T>? _tail1)
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

        if (data.CompareTo(_tail!.Data) >= 0)
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

    // Sort in descending order
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

    // Show the fashion(s)
    public List<T> GetModes()
    {
        var frequencies = GetFrequencies();
        var modes = new List<T>();
        if (frequencies.Count == 0) return modes;

        int maxFreq = frequencies.Values.Max();
        foreach (var pair in frequencies)
        {
            if (pair.Value == maxFreq)
            {
                modes.Add(pair.Key);
            }
        }
        return modes;
    }

    // show the graph
    public Dictionary<T, int> GetFrequencies()
    {
        var frequencies = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (current.Data != null)
            {
                if (frequencies.ContainsKey(current.Data))
                    frequencies[current.Data]++;
                else
                    frequencies[current.Data] = 1;
            }
            current = current.Next;
        }
        return frequencies;
    }

    // It exists
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

    //  Remove an occurrence
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head && current == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head!.Next;
                    _head!.Prev = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail!.Prev;
                    _tail!.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Remove all occurrences
    public int RemoveAll(T data)
    {
        int count = 0;
        var current = _head;
        while (current != null)
        {
            var nextNode = current.Next;
            if (current.Data != null && current.Data.Equals(data))
            {
                if (current == _head && current == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Prev = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    _tail!.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                count++;
            }
            current = nextNode;
        }
        return count;
    }

    public override string ToString()
    {
        if (_head == null) return "La lista está vacía.";
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
        if (_tail == null) return "La lista está vacía.";
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