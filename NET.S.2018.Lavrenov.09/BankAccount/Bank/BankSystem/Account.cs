using System;

namespace BankSystem
{
    /// <summary>
    /// abstract class for creating accounts
    /// </summary>
    public abstract class Account : IEquatable<Account>
    {
        #region Feilds & prop

        private readonly string _id;
        private string _client;
        private decimal _balance;
        private int _bonusPoints;
        public AccountType AccountType { get; }
        public string Person
        {
            get => _client;
            private set => _client = value ?? throw new ArgumentException(nameof(value));
        }

        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (!IsValidBalance(value))
                {
                    throw new ArgumentException(nameof(value));
                }

                _balance = value;
            }
        }

        public int BonusPoints
        {
            get => _bonusPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _bonusPoints = value;
            }
        }
        #endregion

        #region Ctors

        protected Account(string id, string person)
        {
            _id = id;
            Person = person;
        }

        protected Account(string id, string person, decimal balance) : this(id, person)
        {
            Balance = balance;
        }

        protected Account(string id, string person, decimal balance, AccountType accType) : this(id, person, balance)
        {
            AccountType = accType;
        }

        #endregion


        #region IEquatable

        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_id, other._id) && _balance == other._balance && _bonusPoints == other._bonusPoints;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Account)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _balance.GetHashCode();
                hashCode = (hashCode * 397) ^ _bonusPoints;
                return hashCode;
            }
        }

        #endregion

        #region Abstract metods

        protected abstract bool IsValidBalance(decimal value);
        protected abstract int CalculateBonusPoints(decimal value);

        #endregion

        #region Public API

        public void Deposite(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(value));
            }

            Balance += value;
            BonusPoints += CalculateBonusPoints(value);
        }
        public void WithDraw(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(value));
            }

            Balance -= value;
            BonusPoints -= CalculateBonusPoints(value);
        }

        #endregion

        #region Ovverride ToString()

        public override string ToString()
        {
            return $"Account id: {_id} Balance: {_balance} Owner: {Person.ToString()}";
        }

        #endregion
    }

}
