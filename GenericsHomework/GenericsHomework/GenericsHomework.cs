namespace GenericsHomework
{
	public class Node<T>
		where T : notnull
	{
		private T data;
		private Node<T> next;

		public Node(T parms)
		{
			data = parms;
			next = this;
		}

		private Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

		public override string ToString()
		{
			return "" + data.ToString();
		}

		public void Append(T args)
		{
			if(Exists(args)){
				throw new ArgumentOutOfRangeException();
			}

			Node<T> head = next;
			
			next = new Node<T>(args);

			next.next = head;

		}

		//Because this is not a circular list and it does not contain and references to the previous node, 
		//when reassigned as the previous members of the list will fall out of scope and therefor we do not need to unassign each of them.
		public void Clear(){
			if(next == this){
				return;
			}

			Node<T> cur = next;

			while(cur.next != this){
				cur = cur.next;
			}

			Node<T> placeholder = cur.next;

			cur.next = cur;

			placeholder.next = placeholder;
		}

		public bool Exists(T args)
		{
			bool sameType(T arg1, T arg2){
				return arg1.GetType == arg2.GetType;
			}

			Node<T> cur = this;
			
			do
			{
				if(sameType(cur.data, args)){
					if(cur.data.Equals(args)){
						return true;
					}
				}

			}while(cur.next != this);

			return false;
		}
	}
}