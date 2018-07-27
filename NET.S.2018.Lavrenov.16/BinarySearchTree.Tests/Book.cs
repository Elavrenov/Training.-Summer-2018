using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class Book : IComparable<Book>
    {
        public int Heigth { get; set; }


        public int CompareTo(Book otherBook)
        {
            if (ReferenceEquals(this, otherBook))
            {
                return 0;
            }

            if (otherBook is null)
            {
                return 1;
            }

            return Heigth.CompareTo(otherBook.Heigth);
        }
    }
}
