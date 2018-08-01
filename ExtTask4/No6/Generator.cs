using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No6
{
    public static class Generator<T>
    {
        public static IEnumerable<T> GetSequence(T x1, T x2, Func<T, T, T> func, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{amount} can't be less or equals zero");
            }

            if (func == null)
            {
                throw new ArgumentNullException($"{nameof(func)} can't be null");
            }

            if (x1 == null || x2 == null)
            {
                throw new ArgumentNullException($"{x1},{x2} wrong args");
            }

            T current = x1;
            T next = x2;

            for (int i = 0; i < amount; i++)
            {
                yield return current;

                T temp = func(next, current);
                current = next;
                next = temp;
            }
        }
    }
}
