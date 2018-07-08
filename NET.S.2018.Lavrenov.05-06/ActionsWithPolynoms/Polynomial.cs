using System;
using System.Text;

namespace ActionsWithPolynoms
{
    public sealed class Polynomial
    {
        #region Const

        /// <summary>
        /// Allowable difference with cofficients
        /// </summary>
        private const double Accuracy = 0.001;

        #endregion

        #region Fields and property

        /// <summary>
        /// Cofficients array with
        /// get only acsessor
        /// </summary>
        private double[] CofficientsArray { get; }

        /// <summary>
        /// Maximal polynom degree
        /// </summary>
        private int Degree { get; }

        #endregion

        #region Ctors

        /// <summary>
        /// Constructor wiht 0 args
        /// </summary>
        public Polynomial()
        {
            CofficientsArray = Array.Empty<double>();
            Degree = 0;
        }

        /// <summary>
        /// Constructor with n args
        /// </summary>
        /// <param name="cofficients"></param>
        public Polynomial(params double[] cofficients)
        {
            CofficientsArray = new double[cofficients.Length];

            for (int i = 0; i < cofficients.Length; i++)
            {
                CofficientsArray[i] = cofficients[i];
            }

            Degree = CofficientsArray.Length - 1;
        }

        /// <summary>
        /// Сonstructor based on another polynomial
        /// </summary>
        /// <param name="polynom"></param>
        public Polynomial(Polynomial polynom)
        {
            CofficientsArray = new double[polynom.CofficientsArray.Length];

            for (int i = 0; i < polynom.CofficientsArray.Length; i++)
            {
                CofficientsArray[i] = polynom.CofficientsArray[i];
            }

            Degree = polynom.Degree;
        }

        #endregion

        #region Public API

        /// <summary>
        /// The method compares two polynomials with each other
        /// </summary>
        /// <param name="otherPolynom"></param>
        /// <returns>
        /// Returns true if two polynomials are equal or false in the all opposite cases
        /// </returns>
        public bool Equals(Polynomial otherPolynom)
        {
            if (otherPolynom is null)
            {
                return false;
            }

            if (ReferenceEquals(this, otherPolynom))
            {
                return true;
            }

            if (GetType() != otherPolynom.GetType()
                || CofficientsArray.Length != otherPolynom.CofficientsArray.Length)
            {
                return false;
            }

            for (int i = 0; i < CofficientsArray.Length; i++)
            {
                if (CofficientsArray[i] - otherPolynom.CofficientsArray[i] < Accuracy)
                {
                    return false;
                }
            }

            return true;
        }

        #region Overrided object methods

        /// <summary>
        /// Ovverrided object method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Equals method for 2 polynomials or false
        /// in the all opposite cases
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!(obj is Polynomial))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Overrided object method
        /// </summary>
        /// <returns>
        /// The unique value of each polynomial
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            Random rd = new Random();

            foreach (var item in CofficientsArray)
            {
                hashCode ^= (int)(Degree + item);
            }

            return hashCode + rd.Next(Int32.MaxValue);
        }

        /// <summary>
        /// Overrided object method
        /// </summary>
        /// <returns>
        /// A string representation of a polynomial
        /// </returns>
        /// <exception cref="ArgumentNullException">if Cofficients Array is null</exception>
        public override string ToString()
        {
            if (CofficientsArray is null)
            {
                throw new ArgumentNullException($"{nameof(CofficientsArray)} is null");
            }

            StringBuilder returnString = new StringBuilder();


            int n = Degree;

            for (int i = 0; i < CofficientsArray.Length - 1; i++, n--)
            {
                returnString.Append($"({CofficientsArray[i]})x^{n} + ");
            }

            returnString.Append($"({CofficientsArray[CofficientsArray.Length - 1]})");

            return returnString.ToString();
        }

        #endregion

        #region Overloaded operations

        /// <summary>
        /// Ovverloaded plus operator
        /// </summary>
        /// <param name="left">The first polynomial</param>
        /// <param name="right">The second polynomial</param>
        /// <returns>Sum of 2 polynomials or one of them (lenght = 0)</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (left is null)
            {
                throw new ArgumentNullException($"{nameof(left)} is null");
            }

            if (right is null)
            {
                throw new ArgumentNullException($"{nameof(right)} is null");
            }

            if (right.CofficientsArray.Length == 0)
            {
                return left;
            }

            if (left.CofficientsArray.Length == 0)
            {
                return right;
            }

            return Add(left, right);
        }

        /// <summary>
        /// Overloaded - operator
        /// The method changes the signs of the polynomial to opposite
        /// </summary>
        /// <param name="polynom">Polynomial</param>
        /// <returns>Opposite polynomial</returns>
        public static Polynomial operator -(Polynomial polynom)
        {
            if (polynom is null)
            {
                throw new ArgumentException($"{nameof(polynom)} is null");
            }

            double[] newCofficients = new double[polynom.CofficientsArray.Length];

            for (int i = 0; i < polynom.CofficientsArray.Length; i++)
            {
                newCofficients[i] = -polynom.CofficientsArray[i];
            }

            return new Polynomial(newCofficients);
        }

        /// <summary>
        /// Overloaded substraction operator
        /// </summary>
        /// <param name="left">First polynomial</param>
        /// <param name="right">Second polynomial</param>
        /// <returns>Вifference of 2 polynomials or one of them (lenght = 0)</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {

            if (left is null)
            {
                throw new ArgumentNullException($"{nameof(left)} is null");
            }

            if (left.CofficientsArray.Length == 0)
            {
                return right;
            }

            if (right is null)
            {
                throw new ArgumentNullException($"{nameof(right)} is null");
            }

            if (right.CofficientsArray.Length == 0)
            {
                return left;
            }

            return Add(left, -right);
        }

        /// <summary>
        /// Overloaded multiplication operator
        /// </summary>
        /// <param name="left">First polynomial</param>
        /// <param name="right">Second polynomial</param>
        /// <returns>Product of two polynomials</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (left is null)
            {
                throw new ArgumentNullException($"{nameof(left)} is null");
            }

            if (left.CofficientsArray.Length == 0)
            {
                return right;
            }

            if (right is null)
            {
                throw new ArgumentNullException($"{nameof(right)} is null");
            }

            if (right.CofficientsArray.Length == 0)
            {
                return left;
            }

            return Multiply(left, right);
        }

        /// <summary>
        /// Overloaded == operator
        /// </summary>
        /// <param name="left">First polynomial</param>
        /// <param name="right">Second polynomial</param>
        /// <returns>True if two polynomials are equals and false in another cases</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static bool operator ==(Polynomial left, Polynomial right)
        {
            if (left is null)
            {
                throw new ArgumentNullException($"{nameof(left)} is null");
            }

            if (left.CofficientsArray.Length == 0)
            {
                return false;
            }

            if (right is null)
            {
                throw new ArgumentNullException($"{nameof(right)} is null");
            }

            if (right.CofficientsArray.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < left.CofficientsArray.Length; i++)
            {
                if (left.CofficientsArray[i] - right.CofficientsArray[i] > Accuracy)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Overloaded != operator
        /// </summary>
        /// <param name="left">Fist polynomial</param>
        /// <param name="right">Second polynomial</param>
        /// <returns>True if two polynomials are not equals and false in another cases</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static bool operator !=(Polynomial left, Polynomial right)
        {
            if (left is null)
            {
                throw new ArgumentNullException($"{nameof(left)} is null");
            }

            if (left.CofficientsArray.Length == 0)
            {
                return false;
            }

            if (right is null)
            {
                throw new ArgumentNullException($"{nameof(right)} is null");
            }

            if (right.CofficientsArray.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < left.CofficientsArray.Length; i++)
            {
                if (left.CofficientsArray[i] - right.CofficientsArray[i] > Accuracy)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion

        #region Private API

        private static Polynomial Add(Polynomial left, Polynomial right)
        {
            double[] newCofficients = new double
                [Math.Max(left.CofficientsArray.Length, right.CofficientsArray.Length)];

            double[] bigArray;
            double[] littleArray;

            if (left.CofficientsArray.Length >= right.CofficientsArray.Length)
            {
                bigArray = left.CofficientsArray;
                littleArray = right.CofficientsArray;
            }
            else
            {
                bigArray = right.CofficientsArray;
                littleArray = left.CofficientsArray;
            }

            int stopIndex = littleArray.Length - 1;


            for (int i = 0; i < newCofficients.Length; i++)
            {
                while (i <= stopIndex)
                {
                    newCofficients[i] = left.CofficientsArray[i] + right.CofficientsArray[i];
                    i++;
                }

                newCofficients[i] += bigArray[i];
            }

            return new Polynomial(newCofficients);
        }

        private static Polynomial Multiply(Polynomial left, Polynomial right)
        {

            double[] newCofficients = new double[left.CofficientsArray.Length + right.CofficientsArray.Length - 1];

            for (int i = 0; i < left.CofficientsArray.Length; i++)
            {
                for (int j = 0; j < right.CofficientsArray.Length; j++)
                {
                    newCofficients[i + j] += left.CofficientsArray[i] * right.CofficientsArray[j];
                }
            }

            return new Polynomial(newCofficients);
        }

        #endregion
    }
}