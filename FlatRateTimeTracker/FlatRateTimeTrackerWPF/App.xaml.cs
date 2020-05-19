using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FlatRateTimeTrackerWPF.ViewModels;

namespace FlatRateTimeTrackerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel MainVM { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainVM = new MainViewModel();
            MainWindow main = new MainWindow(MainVM);
            base.OnStartup(e);
            main.Show();
        }
    }
}
