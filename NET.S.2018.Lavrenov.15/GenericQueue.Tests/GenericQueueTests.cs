namespace GenericQueue.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

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
            Assert.Throws<ArgumentException>(() => new CustomQueue<string>(-1));
            Assert.Throws<ArgumentNullException>(() => new CustomQueue<Person>(null));
            Assert.Throws<ArgumentException>(() => new CustomQueue<int>(-1));
            Assert.Throws<ArgumentException>(() => queueCust1.Dequeque());
            Assert.Throws<ArgumentException>(() => queueCust2.Peek());
        }
    }
}
