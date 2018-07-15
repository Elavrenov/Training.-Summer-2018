namespace BankAccount
{
    using System;

    /// <summary>
    /// Class with person information
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Client name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Client second name
        /// </summary>
        public string SecondName { get; }

        /// <summary>
        /// Client adress
        /// </summary>
        public string Adress { get; }

        /// <summary>
        /// Constructor for creating person
        /// </summary>
        /// <param name="firstName">Client first name</param>
        /// <param name="secondName">Client second name</param>
        /// <param name="adress">Client adress</param>
        public Person(string firstName, string secondName, string adress)
        {
            FirstName = firstName;
            SecondName = secondName;
            Adress = adress;
        }

        /// <summary>
        /// Method for giving information about client
        /// </summary>
        public void GetPersonInfo()
        {
            Console.WriteLine($"Client: {FirstName} {SecondName}, Adress: {Adress}");
        }
    }
}
