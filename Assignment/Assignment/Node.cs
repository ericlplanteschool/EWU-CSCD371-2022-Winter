using System.Collections;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<Node<T>>
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

        public IEnumerator<Node<T>> GetEnumerator()
        {

            Node<T> cur = this;

            do
            {
                yield return cur;
                cur = cur.Next;
            } 
            while (cur != this);
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int max)
        {
            Node<T> cur = this;
            int num = 0;

            do
            {
                yield return cur;
                cur = cur.Next;
                num++;
            }

            while(num < max);
        }
    }
}
