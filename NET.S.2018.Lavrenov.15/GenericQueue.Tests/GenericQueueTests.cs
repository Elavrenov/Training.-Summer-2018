namespace GenericQueue.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class GenericQueueTests
    {
        private TQueue<int> queueInt1 = new TQueue<int>();
        private TQueue<int> queueInt2 = new TQueue<int>(3);
        private TQueue<int> queueInt3 = new TQueue<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
        private TQueue<int> queueInt4 = new TQueue<int>(new List<int>(new[] { 1, 2, 3, 4, 5 }));

        private TQueue<string> queueStr1 = new TQueue<string>();
        private TQueue<string> queueStr2 = new TQueue<string>(3);
        private TQueue<string> queueStr3 = new TQueue<string>(new[] { "1", "2", "3", "4", "5", "6", "7" });
        private TQueue<string> queueStr4 = new TQueue<string>(new List<string>(new[] { "1", "2", " 3", "4", "5" }));

        static Person p1 = new Person("Ivan", 25);
        static Person p2 = new Person("Ray", 1);
        static Person p3 = new Person("Falcona", 222);

        private TQueue<Person> queueCust1 = new TQueue<Person>();
        private TQueue<Person> queueCust2 = new TQueue<Person>(3);
        private TQueue<Person> queueCust3 = new TQueue<Person>(new Person[] { p1, p2 });
        private TQueue<Person> queueCust4 = new TQueue<Person>(new List<Person>(new Person[] { p1, p2, p3 }));


        [Test]
        public void QueuesCountTest()
        {
            Assert.AreEqual(queueStr1.Count, 0);
            Assert.AreEqual(queueStr2.Count, 0);
            Assert.AreEqual(queueStr3.Count, 7);
            Assert.AreEqual(queueStr4.Count, 5);

            Assert.AreEqual(queueInt1.Count, 0);
            Assert.AreEqual(queueInt2.Count, 0);
            Assert.AreEqual(queueInt4.Count, 5);
        }

        [TestCase("1")]
        [TestCase("7")]
        [TestCase("4")]
        [TestCase("2")]
        public void QueuesContainsTest1(string s)
        {
            if (queueStr3.Contains(s))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void QueuesContainsTest2()
        {
            if (queueCust3.Contains(p1))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase("WALLMART")]
        [TestCase("qqq")]
        [TestCase("11")]
        [TestCase("8")]
        public void QueuesNotContainsTest(string s)
        {
            if (queueStr3.Contains(s))
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void EnqueueDequeueForeachTest1()
        {
            queueInt3.Enqueue(3);
            queueInt3.Enqueue(2);
            queueInt3.Dequeque();

            int i = -1;
            int[] expected = new[] { 2, 3, 4, 5, 6, 7, 3, 2 };

            foreach (var item in queueInt3)
            {
                Assert.AreEqual(expected[++i], item);
            }

        }

        [Test]
        public void EnqueueDequeueForeachTest2()
        {
            queueCust4.Enqueue(p1);
            queueCust4.Enqueue(p1);
            queueCust4.Enqueue(p1);
            queueCust4.Dequeque();

            int i = -1;
            Person[] expected = new[] { p2, p3, p1, p1, p1 };

            foreach (var item in queueCust4)
            {
                Assert.AreEqual(expected[++i], item);
            }
        }

        [Test]
        public void QueueClearTest()
        {
            queueCust4.Clear();

            if (queueCust4.Count == 0)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => new TQueue<string>(-1));
            Assert.Throws<ArgumentNullException>(() => new TQueue<Person>(null));
            Assert.Throws<ArgumentException>(() => new TQueue<int>(-1));
            Assert.Throws<ArgumentException>(() => queueCust1.Dequeque());
            Assert.Throws<ArgumentException>(() => queueCust2.Peek());
        }
    }
}
