namespace CustomerProvider
{
    using System;
    using System.Globalization;
    using System.Text;
    using Customer;

    /// <summary>
    /// Format provider class for <see cref="Customer"/>
    /// </summary>
    public sealed class CustomerProvider : IFormatProvider, ICustomFormatter
    {
        #region Fields

        /// <summary>
        /// Parent class definition field
        /// for building chains of format providers
        /// </summary>
        private readonly IFormatProvider _parent;

        #endregion

        #region Ctors

        /// <summary>
        /// Constructor for base class with same culture
        /// </summary>
        public CustomerProvider() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Constructor with 1 argument for
        /// initializing a new instance
        /// </summary>
        /// <param name="parent"></param>
        public CustomerProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        #endregion

        #region IFormatProvider, ICustomFormatter

        /// <summary>
        /// Returns an object that provides new formatting service
        /// </summary>
        /// <param name="formatType">Format type</param>
        /// <returns>
        /// Returns an object that provides formatting services for the specified type 
        /// or null if <paramref name="formatType"/> is not a ICustomFormatter.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Method called whenever the AppendFormat method of the StringBuilder/String 
        /// class needs to get a string for the object.
        /// </summary>
        /// <param name="format">Parameter for formatting</param>
        /// <param name="arg">The object of the class that needs to be formatted</param>
        /// <param name="formatProvider">An object which give information about the instance</param>
        /// <returns>Formatted string</returns>
        /// <exception cref="ArgumentException">if <paramref name="arg"/> is not a Customer</exception>
        /// <exception cref="FormatException">when format is not valid</exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "QWERTY")
            {
                return string.Format(_parent, "{0:" + format + "}", arg);
            }

            if (!(arg is Customer))
            {
                throw new ArgumentException($"{nameof(arg)} wrong type, must be a Customer");
            }

            StringBuilder resultString = new StringBuilder();
            string baseString = string.Format(CultureInfo.InvariantCulture, "{0}", arg);

            foreach (var item in baseString)
            {
                resultString.Append(item);
            }

            return resultString.Append(" QWERTY").ToString();
        }

        #endregion
    }
}
