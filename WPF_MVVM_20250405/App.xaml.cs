using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_20250405.Models;
using WPF_MVVM_20250405.ViewModels;

namespace WPF_MVVM_20250405
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ClassSystem ClassSystem { get; set; }
        public App()
        {
            ClassSystem = new ClassSystem();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel(ClassSystem);
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
