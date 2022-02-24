namespace GenericsHomework
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("Existing value.");
            }
            else
            {
                Node<T> newNode = new(value);
                newNode.Next = Next;
                Next = newNode;
            }
        }

        public void Clear()
        {
            Next = this;
        }

        public bool Exists(T value)
        {
            Node<T> current = this;
            do
            {
                if (current.Value is not null)
                {
                    if (current.Value.Equals(value))
                    {
                        return true;
                    }
                }
                current = current.Next;
            } while (current != this);
            return false;
        }

    }
}
