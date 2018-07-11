using System;
using System.Linq;
using System.Text;

namespace ActionsWithPolynoms
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public sealed class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        #region Const

        /// <summary>
        /// Allowable difference with cofficients
        /// </summary>
        private const double Accuracy = 10e-10;

        #endregion

        #region Fields and property

        /// <summary>
        /// Cofficients array with
        /// </summary>
        private readonly double[] _cofficientsArray;

        /// <summary>
        /// Maximal polynom degree
        /// </summary>
        public int Degree => _cofficientsArray.Length - 1;

        #endregion

        #region Ctors

        /// <summary>
        /// Constructor wiht 0 args
        /// </summary>
        public Polynomial()
        {
            _cofficientsArray = Array.Empty<double>();
        }

        /// <summary>
        /// Constructor with n args
        /// </summary>
        /// <param name="cofficients"></param>
        public Polynomial(params double[] cofficients)
        {
            _cofficientsArray = new double[cofficients.Length];

            for (int i = 0; i < cofficients.Length; i++)
            {
                _cofficientsArray[i] = cofficients[i];
            }
        }

        /// <summary>
        /// Сonstructor based on another polynomial
        /// </summary>
        /// <param name="polynom"></param>
        public Polynomial(Polynomial polynom)
        {
            _cofficientsArray = new double[polynom._cofficientsArray.Length];

            for (int i = 0; i < polynom._cofficientsArray.Length; i++)
            {
                _cofficientsArray[i] = polynom[i];
            }
        }

        #endregion

        #region Public API

        #region IEuqatable

        /// <summary>
        /// The method compares two polynomials with each other
        /// </summary>
        /// <param name="otherPolynom"></param>
        /// <returns>
        /// Returns true if two polynomials are equal or false in the all opposite cases
        /// </returns>
        public bool Equals(Polynomial otherPolynom)
        {
            if (ReferenceEquals(this, otherPolynom))
            {
                return true;
            }

            if (otherPolynom is null)
            {
                return false;
            }

            if (GetType() != otherPolynom.GetType()
                || Degree != otherPolynom.Degree)
            {
                return false;
            }

            for (int i = 0; i < _cofficientsArray.Length; i++)
            {
                if (Math.Abs(_cofficientsArray[i] - otherPolynom._cofficientsArray[i]) > Accuracy)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Ovverrided object method
        /// </summary>
        /// <param name="obj">some object</param>
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

            return Equals((Polynomial)obj);
        }

        #endregion

        #region ICloneable

        /// <summary>
        /// Create polynomial clone
        /// </summary>
        /// <returns>clone of this polynomial</returns>
        /// <inheritdoc cref="object"/>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>
        /// Create polynomial clone
        /// </summary>
        /// <returns>clone of this polynomial</returns>
        public Polynomial Clone()
        {
            return new Polynomial(_cofficientsArray);
        }

        #region Overrided object methods

        /// <summary>
        /// Overrided object method
        /// </summary>
        /// <returns>
        /// The unique value of each polynomial
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (var item in _cofficientsArray)
            {
                hashCode ^= (int)(Degree + item);
            }

            return hashCode;
        }

        #endregion

        /// <summary>
        /// Overrided object method
        /// </summary>
        /// <returns>
        /// A string representation of a polynomial
        /// </returns>
        /// <exception cref="ArgumentNullException">if Cofficients Array is null</exception>
        public override string ToString()
        {
            if (_cofficientsArray is null)
            {
                throw new ArgumentNullException($"{nameof(_cofficientsArray)} is null");
            }

            StringBuilder returnString = new StringBuilder();

            int n = Degree;

            for (int i = 0; i < _cofficientsArray.Length - 1; i++, n--)
            {
                returnString.Append($"({_cofficientsArray[i]})x^{n} + ");
            }

            returnString.Append($"({_cofficientsArray[_cofficientsArray.Length - 1]})");

            return returnString.ToString();
        }

        #endregion

        #region Overloaded operations

        /// <summary>
        /// Ovverloaded plus operator
        /// </summary>
        /// <param name="lhs">The first polynomial</param>
        /// <param name="rhs">The second polynomial</param>
        /// <returns>Sum of 2 polynomials or one of them (lenght = 0)</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null");
            }

            if (rhs._cofficientsArray.Length == 0)
            {
                return lhs;
            }

            if (lhs._cofficientsArray.Length == 0)
            {
                return rhs;
            }

            return Add(lhs, rhs);
        }

        /// <summary>
        ///  
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

            double[] newCofficients = new double[polynom._cofficientsArray.Length];

            for (int i = 0; i < polynom._cofficientsArray.Length; i++)
            {
                newCofficients[i] = -polynom[i];
            }

            return new Polynomial(newCofficients);
        }

        /// <summary>
        /// Overloaded substraction operator
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Вifference of 2 polynomials or one of them (lenght = 0)</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {

            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null");
            }

            if (lhs._cofficientsArray.Length == 0)
            {
                return rhs;
            }

            if (rhs._cofficientsArray.Length == 0)
            {
                return lhs;
            }

            return Add(lhs, -rhs);
        }

        /// <summary>
        /// Overloaded multiplication operator
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Product of two polynomials</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null");
            }

            if (lhs._cofficientsArray.Length == 0)
            {
                return rhs;
            }

            if (rhs._cofficientsArray.Length == 0)
            {
                return lhs;
            }

            return Multiply(lhs, rhs);
        }

        /// <summary>
        /// Overloaded multiplication operator
        /// </summary>
        /// <param name="lhs">Some polynomial</param>
        /// <param name="rhs">Some douuble value</param>
        /// <returns>Product of this terms</returns>
        /// <exception cref="ArgumentNullException">if polynomial is null</exception>
        public static Polynomial operator *(Polynomial lhs, double rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            return Multiply(lhs, new Polynomial(rhs));
        }

        /// <summary>
        /// Overloaded multiplication operator
        /// </summary>
        /// <param name="lhs">Some polynomial</param>
        /// <param name="rhs">Some double value</param>
        /// <returns>Product of this terms</returns>
        /// <exception cref="ArgumentNullException">if polynomial is null</exception>
        public static Polynomial operator *(double lhs, Polynomial rhs)
        {
            if (rhs is null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null");
            }

            return Multiply(rhs, new Polynomial(lhs));
        }

        /// <summary>
        /// Overloaded division by double operator
        /// </summary>
        /// <param name="lhs">Some polynomial</param>
        /// <param name="rhs">Some double value</param>
        /// <returns>Quotient of this terms</returns>
        /// <exception cref="ArgumentNullException">if polynomial is null</exception>
        /// <exception cref="DivideByZeroException">if double is zero</exception>
        public static Polynomial operator /(Polynomial lhs, double rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            if (rhs - 0 < Accuracy)
            {
                throw new DivideByZeroException($"{rhs} zero divisor");
            }

            return DivideByDouble(lhs, rhs);
        }

        /// <summary>
        /// Overloaded == operator
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>True if two polynomials are equals and false in another cases</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (ReferenceEquals(lhs, null))
            {
                return false;
            }

            if (ReferenceEquals(null, rhs))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Overloaded != operator
        /// </summary>
        /// <param name="lhs">Fist polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>True if two polynomials are not equals and false in another cases</returns>
        /// <exception cref="ArgumentException">if one of polynomials is null</exception>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Indexer for class Polynomial
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>N-coefficient of polynomial</returns>
        /// <exception cref="ArgumentOutOfRangeException">If index is not valid</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                {
                    throw new ArgumentOutOfRangeException($"{index} is not valid index");
                }

                return _cofficientsArray[index];
            }
            private set
            {
                if (index < 0 || index > Degree)
                {
                    throw new ArgumentOutOfRangeException($"{index} is not valid index");
                }

                _cofficientsArray[index] = value;
            }
        }

        #endregion

        #endregion

        #region Private API

        private static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            double[] newCofficients = new double
                [Math.Max(lhs._cofficientsArray.Length, rhs._cofficientsArray.Length)];

            double[] bigArray = lhs.Degree >= rhs.Degree ? lhs._cofficientsArray : rhs._cofficientsArray;
            double[] littleArray = lhs.Degree < rhs.Degree ? lhs._cofficientsArray : rhs._cofficientsArray;

            int stopIndex = littleArray.Length - 1;

            for (int i = 0; i < newCofficients.Length; i++)
            {
                while (i <= stopIndex)
                {
                    newCofficients[i] = lhs[i] + rhs[i];
                    i++;
                }

                newCofficients[i] += bigArray[i];
            }

            return new Polynomial(newCofficients);
        }

        private static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {

            double[] newCofficients = new double[lhs._cofficientsArray.Length + rhs._cofficientsArray.Length - 1];

            for (int i = 0; i < lhs._cofficientsArray.Length; i++)
            {
                for (int j = 0; j < rhs._cofficientsArray.Length; j++)
                {
                    newCofficients[i + j] += lhs[i] * rhs[j];
                }
            }

            return new Polynomial(newCofficients);
        }

        private static Polynomial DivideByDouble(Polynomial lhs, double rhs)
        {
            double[] newCofficients = new double[lhs._cofficientsArray.Length];

            for (int i = 0; i < lhs._cofficientsArray.Length; i++)
            {
                newCofficients[i] = lhs[i] / rhs;
            }

            return new Polynomial(newCofficients);
        }

        #endregion
    }
}