using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
	public class Node<T> : IEnumerable<Node<T>>
		where T : notnull
	{
		private T _data;
		private Node<T> _next;

		public Node(T parms)
		{
			_data = parms;
			_next = this;
		}

		private Node<T> Next
		{
			get { return _next; }
			set { _next = value; }
		}

		public override string? ToString()
		{
			return _data?.ToString();
		}

		public void Append(T args)
		{
			if (Exists(args))
			{
				throw new ArgumentException();
			}

			Node<T> head = _next;

			_next = new Node<T>(args);

			_next._next = head;

		}

		public void Clear()
		{
			if (_next == this)
			{
				return;
			}

			Node<T> cur = _next;

			while (cur._next != this)
			{
				cur = cur._next;
			}

			Node<T> placeholder = cur._next;

			cur._next = cur;

			placeholder._next = placeholder;
		}

		public bool Exists(T arg)
		{

			Node<T> cur = this;

			do
			{
				if (cur._data.Equals(arg))
				{
					return true;
				}
				

				cur = cur._next;

			} while (cur._next != this);

			return false;
		}

		public IEnumerator<Node<T>> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}

	
