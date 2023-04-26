using System.Collections.Generic;
using Newtonsoft.Json;

namespace Homework_11
{
    /// <summary>
    /// Departmanet structure
    /// </summary>
    class Department : Company
    {
        #region Fields

        static private int count = 0;

        private int departmentID;

        private List<Worker> workers;

        #endregion


        #region Properties

        [JsonProperty("Workers")]
        public List<Worker> Workers { get { return this.workers; } set { this.workers = value; } }

        [JsonProperty("DepartmentID")]
        public int DepartmentID { get { return this.departmentID; } set { this.departmentID = value; } }

        [JsonProperty("Count")]
        public int Count { get { return count; } }
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Title">Department title</param>
        public Department(string Title) : base(Title)
        {
            this.departmentID = count;
            count++;
            this.workers = new List<Worker>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adding new worker
        /// </summary>
        /// <param name="worker">Работник</param>
        public void AddWorker(Worker worker)
        {
            this.workers.Add(worker);
        }

        /// <summary>
        /// Delete worker
        /// </summary>
        /// <param name="index">Индекс работника</param>
        public void DeleteWorker(int index)
        {
            this.workers.RemoveAt(index - 1);
        }

        /// <summary>
        /// Editing worker
        /// </summary>
        /// <param name="firstName">New first name</param>
        /// <param name="lastName">New last name</param>
        /// <param name="age">New age</param>
        /// <param name="salary">New salary</param>
        /// <param name="numberProjects">New number of projects</param>
        /// <param name="index">Index</param>
        public void EditWorker(string firstName, string lastName, byte age, int salary, byte numberProjects, int index)
        {
            this.workers[index - 1].FirstName = firstName;
            this.workers[index - 1].LastName = lastName;
            this.workers[index - 1].Age = age;
            this.workers[index - 1].Salary = salary;
            this.workers[index - 1].NumberProjects = numberProjects;
        }

        #endregion
    }
}
