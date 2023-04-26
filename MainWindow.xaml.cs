using System;
using System.Windows;


namespace Homework_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company company;

        public MainWindow()
        {
            InitializeComponent();
            company = new Company("");
            tree.ItemsSource = company.Departments;

        }

        /// <summary>
        /// Opening button
        /// </summary>
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            company.OpenCompany();
            tree.ItemsSource = company.Departments;
        }

        /// <summary>
        /// Saving button
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            company.SaveCompany();
        }

        /// <summary>
        /// Adding new department
        /// </summary>
        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            Company temp;
            Department department = tree.SelectedItem as Department;
            if (department != null) temp = department;
            else temp = company;
            if (DepartmentName.Text != "") temp.AddDepartment(new Department(DepartmentName.Text));
            tree.Items.Refresh();
        }

        /// <summary>
        /// Deleteing department
        /// </summary>
        private void DeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (tree.SelectedItem != null)
            {
                Department Department = tree.SelectedItem as Department;
                Company ParentDepartment = company.FindParentDepartment(Department.DepartmentID, company);
                ParentDepartment.DeleteDepartment(Department);
                tree.Items.Refresh();
                Workers.ItemsSource = null;
            }
        }

        /// <summary>
        /// Editin department
        /// </summary>
        private void EditDepartment_Click(object sender, RoutedEventArgs e)
        {
            Department Department = tree.SelectedItem as Department;
            if (Department != null)
            {
                Company ParentDepartment = company.FindParentDepartment(Department.DepartmentID, company);
                ParentDepartment.EditDepartment(DepartmentName.Text, Department.DepartmentID);
                tree.Items.Refresh();
            }
        }

        /// <summary>
        /// Adding worker to the department
        /// </summary>
        private void AddWorkers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (tree.SelectedItem as Department).AddWorker(new Worker(FirstName.Text, LastName.Text, Convert.ToByte(Age.Text), Convert.ToInt32(Salary.Text),
                    Convert.ToByte(NumberProjects.Text)));
                Workers.Items.Refresh();
            }
            catch { }
        }


        /// <summary>
        /// Filling table of workers
        /// </summary>
        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tree.SelectedItem != null) Workers.ItemsSource = (tree.SelectedItem as Department).Workers;
        }


        /// <summary>
        /// Editing worker
        /// </summary>
        private void EditWorkers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (tree.SelectedItem as Department).EditWorker(FirstName.Text, LastName.Text, Convert.ToByte(Age.Text), Convert.ToInt32(Salary.Text),
                    Convert.ToByte(NumberProjects.Text), Workers.SelectedIndex + 1);
                Workers.Items.Refresh();
            }
            catch { }
        }


        /// <summary>
        /// Deleting chosend worker
        /// </summary>
        private void DeleteWorkers_Click(object sender, RoutedEventArgs e)
        {
            if (tree.SelectedItem != null && Workers.SelectedIndex != -1)
                (tree.SelectedItem as Department).DeleteWorker((Workers.SelectedIndex + 1));
            Workers.Items.Refresh();
        }
    }
}
