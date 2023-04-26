using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Homework_11
{
    /// <summary>
    /// Sorting criteria
    /// </summary>
    enum SortCritera
    {
        Name,
        Surname,
        Salary
    }

    /// <summary>
    /// Worker structure
    /// </summary>
    class Worker
    {
        #region Fields

        static private int count = 0;

        private string firstName;

        private string lastName;

        private byte age;

        private int salary;

        private byte numberProjects;

        #endregion

        #region Properties

        [JsonProperty("FirstName")]
        public string FirstName { get { return firstName; } set { firstName = value; } }

        [JsonProperty("LastName")]
        public string LastName { get { return lastName; } set { lastName = value; } }

        [JsonProperty("Age")]
        public byte Age { get { return age; } set { age = value; } }

        [JsonProperty("Salary")]
        public int Salary { get { return salary; } set { salary = value; } }

        [JsonProperty("NumberProjects")]
        public byte NumberProjects { get { return numberProjects; } set { numberProjects = value; } }


        static public int Count { get { return count; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="NumberProjects">Количество проектов</param>
        public Worker(string firstName, string lastName, byte age, int salary, byte numberProjects)
        {
            count++;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            NumberProjects = numberProjects; 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Printing info about worker
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0,10}{1,10}{2,10}{3,10}{4,10}",
                FirstName,
                LastName,
                Age,
                Salary,
                NumberProjects);
        }

        #endregion

        #region Sorting

        private class SortByFirstName : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                return String.Compare(X.FirstName, Y.FirstName);
            }
        }
        private class SortByLastName : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                return String.Compare(X.LastName, Y.LastName);
            }
        }
        private class SortBySalary : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                if (X.Salary == Y.Salary) return 0;
                else if (X.Salary > Y.Salary) return 1;
                else return -1;
            }
        }
        public static IComparer<Worker> SortedBy(SortCritera criterion)
        {
            if (criterion == SortCritera.Name) return new SortByFirstName();
            else if (criterion == SortCritera.Surname) return new SortByLastName();
            else return new SortBySalary();
        }
        #endregion
    }
}