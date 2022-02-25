using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Append_ValueAlreadyExists_ThrowsException()
        {
            Node<string> node = new("Value");
            node.Append("Value");
        }

        [TestMethod]
        public void Append_ValuesDoNotAlreadyExist_Success()
        {
            Node<string> node = new("Apple");
            node.Append("Banana");
            node.Append("Cherry");
            string actualResult = $"{node} {node.Next} {node.Next.Next} {node.Next.Next.Next}";
            string expectedResult = "Apple Cherry Banana Apple";
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        [TestMethod]
        public void Clear_ThreeExistingNodes_OneNodeLeft()
        {
            Node<int> node = new(42);
            node.Append(43);
            node.Append(44);
            node.Clear();
            Assert.AreEqual<int>(node.Value, node.Next.Value);
        }

        [TestMethod]
        public void Constructor_PassedNonNullValue_ValueIsNotNull()
        {
            Node<string> node = new("Inigo Montoya");
            Assert.IsNotNull(node.Value);
        }

        [TestMethod]
        public void ToString_ValueIsInteger_IntegerToStringAndValueToStringAreEqual()
        {
            Node<int> node = new(42);
            Assert.AreEqual<string>(42.ToString(), node.Value.ToString());
        }

        [TestMethod]
        public void IENumberable_ChildItems_returnsCorrectNode()
        {
            Node<string> node = new("first");
            node.Append("fifth");
            node.Append("fourth");
            node.Append("third");
            node.Append("second");

            Assert.AreEqual(node.ChildItems(2).Last(), "second");
            Assert.AreEqual(node.ChildItems(3).Last(), "third");
            Assert.AreEqual(node.ChildItems(4).Last(), "fourth");
            Assert.AreEqual(node.ChildItems(5).Last(), "fifth");
        }
        
        [TestMethod]
        public void GetEnumerator_GivenThreeItems_SuccessfullyEnumeratesThroughList()
        {
            Node<string> node = new("Apple");
            node.Append("Banana");
            node.Append("Cherry");
            string result = node.Select(node => node.Value).Aggregate((nodeList, nextNode) => nodeList + ", " + nextNode);
            Assert.AreEqual("Apple, Cherry, Banana", result);
        }

    }
}
