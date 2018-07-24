using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GenericQueue.Tests
{
    [TestFixture]
    public class GenericQueueTests
    {
        private CustomQueue<int> queueInt1 = new CustomQueue<int>();
        private CustomQueue<int> queueInt2 = new CustomQueue<int>(3);
        private CustomQueue<int> queueInt3 = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
        private CustomQueue<int> queueInt4 = new CustomQueue<int>(new List<int>(new[] { 1, 2, 3, 4, 5 }));

        private CustomQueue<string> queueStr1 = new CustomQueue<string>();
        private CustomQueue<string> queueStr2 = new CustomQueue<string>(3);
        private CustomQueue<string> queueStr3 = new CustomQueue<string>(new[] { "1", "2", "3", "4", "5", "6", "7" });
        private CustomQueue<string> queueStr4 = new CustomQueue<string>(new List<string>(new[] { "1", "2", " 3", "4", "5" }));

        static Person p1 = new Person("Ivan", 25);
        static Person p2 = new Person("Ray", 1);
        static Person p3 = new Person("Falcona", 222);

        private CustomQueue<Person> queueCust1 = new CustomQueue<Person>();
        private CustomQueue<Person> queueCust2 = new CustomQueue<Person>(3);
        private CustomQueue<Person> queueCust3 = new CustomQueue<Person>(new Person[] { p1, p2 });
        private CustomQueue<Person> queueCust4 = new CustomQueue<Person>(new List<Person>(new Person[] { p1, p2, p3 }));


        [Test]
        public void QueuesCountTest()
        {
            Assert.AreEqual(queueInt1.Count, 0);
            Assert.AreEqual(queueInt2.Count, 0);
            Assert.AreEqual(queueInt3.Count, 7);
            Assert.AreEqual(queueInt4.Count, 5);

            Assert.AreEqual(queueStr1.Count, 0);
            Assert.AreEqual(queueStr2.Count, 0);
            Assert.AreEqual(queueStr3.Count, 7);
            Assert.AreEqual(queueStr4.Count, 5);

            Assert.AreEqual(queueCust1.Count, 0);
            Assert.AreEqual(queueCust2.Count, 0);
            Assert.AreEqual(queueCust3.Count, 2);
            Assert.AreEqual(queueCust4.Count, 3);
        }

        [Test]
        public void EnqueueDequeueForeachTest()
        {
            //queueInt3.Enqueue(3);
            //queueInt3.Enqueue(2);
            //queueInt3.Dequeque();

            //int i = -1;
            //int[] expected = new[] {0,2, 3, 4, 5, 6, 7, 3, 2};
            queueCust3.Dequeque();

            foreach (var item in queueCust3)
            {
                Assert.AreEqual(item,2);
            }
        }
    }
}
