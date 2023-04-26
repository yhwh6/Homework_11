using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_11
{
    class Company
    {
        #region Fields

        private string title;

        private DateTime dateOfCreation;

        private List<Department> departments;

        #endregion

        #region Properties

        [JsonProperty("Title")]
        public string Title { get { return this.title; } set { this.title = value; } }

        [JsonProperty("DateOfCreation")]
        public DateTime DateOfCreation { get { return this.dateOfCreation; } private set { this.dateOfCreation = value; } }

        [JsonProperty("Departments")]
        public List<Department> Departments { get { return this.departments; } set { this.departments = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Title">Название Компании</param>
        public Company(string Title)
        {
            this.title = Title;
            this.dateOfCreation = DateTime.Now;
            this.departments = new List<Department>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finding parent department
        /// </summary>
        /// <param name="id">department's id</param>
        /// <param name="company">company</param>
        public Company FindParentDepartment(int id, Company company)
        {
            Company temp = null;
            foreach (var d in company.Departments)
            {
                if (d.DepartmentID == id) temp = company;
                else temp = FindParentDepartment(id, d);
                if (temp != null) break;
            }
            return temp;
        }

        /// <summary>
        /// Deleting department
        /// </summary>
        /// <param name="department">department</param>
        public void DeleteDepartment(Department department)
        {
            this.Departments.Remove(department);
        }

        /// <summary>
        /// Adding department
        /// </summary>
        /// <param name="department">department</param>
        public void AddDepartment(Department department)
        {
            this.Departments.Add(department);
        }

        /// <summary>
        /// Editing department
        /// </summary>
        /// <param name=newtitle">new title</param>
        /// <param name="id">department's id</param>
        public void EditDepartment(string newtitle, int id)
        {
            foreach (var d in Departments)
            {
                if (d.DepartmentID == id) d.Title = newtitle;
            }
        }

        /// <summary>
        /// Unpacking database from file
        /// </summary>
        public void OpenCompany()
        {
            try
            {
                Departments = JsonConvert.DeserializeObject<List<Department>>(File.ReadAllText($"Database.json"));
            }
            catch { }
        }

        /// <summary>
        /// Saving company
        /// </summary>
        public void SaveCompany()
        {
            File.WriteAllText($"Database.json", JsonConvert.SerializeObject(Departments));
        }

        #endregion
    }
}