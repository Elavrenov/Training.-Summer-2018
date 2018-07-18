namespace BankSystem
{
    /// <summary>
    /// class for creating persons
    /// </summary>
    public class Person
    {
        #region Prop

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }

        #endregion

        #region Ctor

        public Person(string fisrtName, string secondName, string email)
        {
            FirstName = fisrtName;
            SecondName = secondName;
            Email = email;
        }

        #endregion

        #region Overrided ToString


        public override string ToString()
        {
            return $"{FirstName} {SecondName} email: {Email}";
        }

        #endregion
    }
}
