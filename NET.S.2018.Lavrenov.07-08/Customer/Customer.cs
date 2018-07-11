namespace Customer
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for creating and validating customeers
    /// and for the representation class objects into the string
    /// </summary>
    public class Customer : IFormattable
    {
        #region Const

        /// <summary>
        /// Regex for validation name
        /// </summary>
        private const string RegexNamePattern = @"(^[A-Z]{1}[a-z]* [A-Z]{1}[a-z]*$)";

        /// <summary>
        /// Regex for validation phone
        /// </summary>
        private const string RegexPhonePattern = @"^\+\d \(\d{3}\) \d{3}-\d{4}";

        /// <summary>
        /// String with ways to format customer object
        /// </summary>
        private const string CustomerFormat = "NRC";

        #endregion

        #region Fields

        /// <summary>
        /// Customer name
        /// </summary>
        private string _name;

        /// <summary>
        /// Customer phone
        /// </summary>
        private string _contactPhone;

        /// <summary>
        /// Customer revenue
        /// </summary>
        private decimal _revenue;

        #endregion

        #region Prop
        /// <summary>
        /// Property for <see cref="_name"/>
        /// </summary>
        /// <exception cref="ArgumentException">name must be in valid format</exception>
        public string Name
        {
            get => _name;
            set
            {
                var regex = new Regex(RegexNamePattern);

                if (regex.IsMatch(value))
                {
                    _name = value;
                    return;
                }

                throw new ArgumentException($"{nameof(value)}: every word must begin with a capital letter");
            }
        }

        /// <summary>
        /// Property for <see cref="_contactPhone"/>
        /// </summary>
        /// <exception cref="ArgumentException">phone must be in valid format</exception>
        public string ContactPhone
        {
            get => _contactPhone;
            set
            {
                var regex = new Regex(RegexPhonePattern);

                if (regex.IsMatch(value))
                {
                    _contactPhone = value;
                    return;
                }

                throw new ArgumentException($"{nameof(value)} must be in format: +X (XXX) XXX-XXXX");
            }
        }

        /// <summary>
        /// Property for <see cref="_revenue"/>
        /// </summary>
        /// <exception cref="ArgumentException">if value less than 0</exception>
        public decimal Revenue
        {
            get => Math.Round(_revenue, 2);
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                _revenue = value;
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor with 3 parameters
        /// </summary>
        /// <param name="name">Customer name</param>
        /// <param name="contactPhone">Customer phone</param>
        /// <param name="revenue">Customer revenue</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        #endregion


        #region Public API

        /// <summary>
        /// Brings a class instance to a string with the specified parameters for formatting
        /// </summary>
        /// <param name="format">
        /// Necessary format:
        /// N-Name only
        /// C-ContactPhone only
        /// R-Revenue only
        /// or combined format(ex. ncr, rc ...)
        /// </param>
        /// <param name="formatProvider"></param>
        /// <returns>Formatted string</returns>
        /// <exception cref="FormatException"> if fomat is not valid</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrEmpty(format) || format == CustomerFormat)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", Name + ", ");
                sb.Append(Revenue.ToString("N2", CultureInfo.InvariantCulture) + ", ");
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", ContactPhone);
                return $"Customer record: {sb}";
            }

            return $"Customer record: {CreateString(format, formatProvider)}";
        }

        #endregion


        #region Private API

        private string CreateString(string format, IFormatProvider fp)
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < format.Length; i++)
            {
                switch (format.ToUpperInvariant()[i])
                {
                    case 'N':
                        resultString.AppendFormat(fp, "{0}", Name);
                        break;
                    case 'C':
                        resultString.AppendFormat(fp, "{0}", ContactPhone);
                        break;
                    case 'R':
                        resultString.Append(Revenue.ToString("N2", fp));
                        break;

                    default: throw new FormatException($"{nameof(format)} is not valid for this class");
                }

                if (i != format.Length - 1)
                {
                    resultString.Append(", ");
                }
            }

            return resultString.ToString();
        }

        #endregion
    }
}
