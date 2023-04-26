using System;
using System.Windows;

namespace Homework_11
{
    /// <summary>
    /// App.xaml 
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            MainWindow mw = new MainWindow();
            app.Run(mw);
        }
    }
}
