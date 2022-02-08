using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GenericsHomeworkTests
{
	[TestClass]
	public class GenericsHomework
	{

		[TestMethod]
		public void Constructor()
		{
			// Arrange.
			//Node<T> node = new Node("") missing using directive?

			// Act.

			// Assert.
			//Assert.IsNotNull(node)
		}

		[TestMethod]
		public void Append()
		{
			// Arrange.
			//var str = "string";
			//Node<T> node = new Node("") missing using directive?

			// Act.
			//node.Append(str)

			// Assert.
			//Assert.AreEqual(str, node.next.data.ToString())
		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Exists()
		{
			// Arrange.
			//var str = "string";
			//Node<T> node = new Node(str) missing using directive?

			// Act.
			//node.Exists(str)
		}

		[TestMethod]
		public void Clear()
		{
			// Arrange.
			//Node<T> node1 = new Node(1) missing using directive?
			//node.append(2);
			//node.append(3);
			//node2 = node1.next;
			//node3 = node2.next;

			// Act.
			//node2.clear();

			// Assert.
			//Assert.AreEqual(node1.next, node1)
			//Assert.AreEqual(node2.next, node2)
			//Assert.AreEqual(node3.next, node3)
		}		
	}
}